
using Dapper;
using iText.Layout;
using MediatR;
using PrashantApi.Application.Services;
using PrashantApi.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.InvoiceMaster.Queries
{
    public class GetInvoicePrintQuery : IRequest<byte[]>
    {
        public int Id { get; set; }
    }

    public class GetInvoicePrintQueryHandler : IRequestHandler<GetInvoicePrintQuery, byte[]>
    {
        private readonly IDbConnectionString _connection;
        private readonly PdfService _pdfService;
        private readonly EmailService _email_service;

        public GetInvoicePrintQueryHandler(PdfService pdfService, EmailService emailService, IDbConnectionString connection)
        {
            _pdfService = pdfService;
            _email_service = emailService;
            _connection = connection;
        }

        public async Task<byte[]> Handle(GetInvoicePrintQuery request, CancellationToken cancellationToken)
        {
            await using var conn = _connection.GetConnection();

            var param = new DynamicParameters();
            param.Add("@Id", request.Id);

            using var multi = await conn.QueryMultipleAsync(
                "usp_GetInvoicePrintDetailsById",
                param,
                commandType: CommandType.StoredProcedure
            );

            // -----------------------
            // Header Section
            // -----------------------
            var headerDyn = await multi.ReadFirstOrDefaultAsync<dynamic>();
            if (headerDyn == null) return Array.Empty<byte>();

            var header = ToCaseInsensitiveDictionary(headerDyn);

            string invoiceNo = SafeGet(header, "InvoiceNo");
            string invoiceDate = SafeGet(header, "InvoiceDate");
            string customerName = SafeGet(header, "CustomerName");
            string customerAddress = SafeGet(header, "CustomerAddress");
            string createdBy = SafeGet(header, "CreatedByName");
            string createdOn = SafeGet(header, "CreatedOn");

            // read numeric header values safely (if needed later)
            decimal.TryParse(SafeGet(header, "GstPercent"), out decimal gstPercent);
            decimal.TryParse(SafeGet(header, "GstAmount"), out decimal gstAmount);
            decimal.TryParse(SafeGet(header, "TransportCharges"), out decimal transportCharges);
            decimal.TryParse(SafeGet(header, "TotalAmount"), out decimal totalAmountHeader);

            // -----------------------
            // Details Section
            // -----------------------
            var detailsDyn = (await multi.ReadAsync<dynamic>()).ToList();

            var invoiceDetails = new List<object>();
            int srNo = 1;
            decimal grandTotal = 0m;

            foreach (var row in detailsDyn)
            {
                var d = ToCaseInsensitiveDictionary(row);

                // read values as strings first, then parse safely
                string jobNo = SafeGet(d, "JobNo");
                string dateReceived = SafeGet(d, "DateReceived");
                string itemName = SafeGet(d, "ItemName");
                string hsnNo = SafeGet(d, "HsnNo");

                // SP returns ItemQty (int), PricePerItem (decimal), ItemTotal (decimal), LabourCharges (decimal), RepairTotal (decimal)
                int.TryParse(SafeGet(d, "ItemQty"), out int itemQty);
                decimal.TryParse(SafeGet(d, "PricePerItem"), out decimal pricePerItem);
                decimal.TryParse(SafeGet(d, "ItemTotal"), out decimal itemTotal);
                decimal.TryParse(SafeGet(d, "LabourCharges"), out decimal labourCharges);
                decimal.TryParse(SafeGet(d, "RepairTotal"), out decimal repairTotal);

                // compute line level totals if you need (here we treat itemTotal as item-only)
                decimal lineTotal = itemTotal + labourCharges + repairTotal;
                grandTotal += lineTotal;

                invoiceDetails.Add(new
                {
                    SrNo = srNo++,
                    JobNo = jobNo,
                    DateReceived = dateReceived,
                    ItemName = itemName,
                    HsnNo = hsnNo,
                    ItemQty = itemQty,
                    PricePerItem = pricePerItem.ToString("0.00"),
                    TaxableValue = 0,
                    ItemTotal = itemTotal.ToString("0.00"),
                    LabourCharges = labourCharges.ToString("0.00"),
                    RepairTotal = repairTotal.ToString("0.00")
                });
            }

            // -----------------------
            // Barcode
            // -----------------------
            var barcodeBytes = _pdfService.GenerateBarcode(invoiceNo);
            string barcodeBase64 = Convert.ToBase64String(barcodeBytes);

            // -----------------------
            // Model for HTML Template
            // -----------------------
            var model = new
            {
                InvoiceNo = string.IsNullOrWhiteSpace(invoiceNo) ? "N/A" : invoiceNo,
                InvoiceDate = string.IsNullOrWhiteSpace(invoiceDate) ? "" : invoiceDate,
                CustomerName = string.IsNullOrWhiteSpace(customerName) ? "" : customerName,
                CustomerAddress = string.IsNullOrWhiteSpace(customerAddress) ? "" : customerAddress,


                InvoiceDetails = invoiceDetails,               // matches template loop {{#each Model.InvoiceDetails}}
                GrandTotal = grandTotal.ToString("0.00"),

                GstPercent = gstPercent.ToString("0.##"),
                GstAmount = gstAmount.ToString("0.00"),
                TransportCharges = transportCharges.ToString("0.00"),
                TotalAmount = totalAmountHeader.ToString("0.00"),

                BarcodeImage = "data:image/png;base64," + barcodeBase64,

                CreatedBy = createdBy,
                CreatedOn = createdOn,
                PrintDate = DateTime.Now.ToString("dd/MM/yyyy"),
                Sign = ""
            };

            // -----------------------
            // Template Path
            // -----------------------
            string templatePath = @"D:\MyWorkSpace\PrashantElectricals\API\31-10-2025\PrashantApi.Application\Template\Invoice.html";

            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Invoice template not found at: {templatePath}");

            // Render HTML (EmailService.Render expects template + model)
            string html = _email_service.Render(templatePath, model);

            // -----------------------
            // Generate PDF
            // -----------------------
            return _pdfService.GeneratePdf(
                DocumentType.Invoice,
                html,
                model.InvoiceNo,
                PageSize.A4,
                false,
                true
            );
        }

        // -----------------------
        // Helper: Convert dynamic to case-insensitive dictionary safely
        // -----------------------
        private static IDictionary<string, object> ToCaseInsensitiveDictionary(dynamic dyn)
        {
            var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (dyn == null) return dict;

            // If it's an Expando or dictionary
            if (dyn is IDictionary<string, object> expando)
            {
                foreach (var kv in expando)
                    dict[kv.Key] = kv.Value;
                return dict;
            }

            // For Dapper's dynamic objects (anonymous objects), use reflection safely
            var props = dyn.GetType().GetProperties();
            foreach (var prop in props)
            {
                try
                {
                    var val = prop.GetValue(dyn);
                    dict[prop.Name] = val ?? "";
                }
                catch
                {
                    // ignore properties that can't be read for any reason
                    dict[prop.Name] = "";
                }
            }

            return dict;
        }

        // -----------------------
        // Helper: safe get string from dictionary
        // -----------------------
        private static string SafeGet(IDictionary<string, object> dict, string key)
        {
            if (dict == null) return string.Empty;
            return dict.TryGetValue(key, out var val) ? val?.ToString() ?? "" : "";
        }
    }
}

