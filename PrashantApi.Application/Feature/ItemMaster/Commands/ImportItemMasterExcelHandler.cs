//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MediatR;
//using OfficeOpenXml;
//using PrashantApi.Application.Interfaces.ItemMaster;
//using PrashantApi.Domain.Entities.ItemMaster;
//using PrashantEle.API.PrashantEle.Application.Common;
//using System.Collections.Generic;
//using System.ComponentModel;
//using ClosedXML.Excel;
//using System.IO;
//using System.Threading;

//namespace PrashantApi.Application.Feature.ItemMaster.Commands
//{
//    public class ImportItemMasterExcelHandler
//        : IRequestHandler<ImportItemMasterExcelCommand, CommandResult>
//    {
//        private readonly IItemMasterRepository _repository;

//        public ImportItemMasterExcelHandler(IItemMasterRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<CommandResult> Handle(
//            ImportItemMasterExcelCommand request,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                var machines = new List<ItemMasterModel>();

//                using var stream = new MemoryStream();
//                await request.File.CopyToAsync(stream, cancellationToken);
//                stream.Position = 0;

//                using var workbook = new XLWorkbook(stream);
//                var worksheet = workbook.Worksheet(1);

//                foreach (var row in worksheet.RowsUsed().Skip(1)) // skip header
//                {
//                    var entity = new ItemMasterModel
//                    {
//                        BrandName = row.Cell(1).GetString().Trim(),

//                        HpKw = ToInt(row.Cell(2)),
//                        Slot = ToInt(row.Cell(3)),
//                        RPM = ToInt(row.Cell(4)),

//                        Pitch = row.Cell(5).GetString()?.Trim(),
//                        Gauge = row.Cell(6).GetString()?.Trim(),
//                        AlterGauge = row.Cell(7).GetString()?.Trim(),

//                        Turn = ToInt(row.Cell(8)),
//                        CoilMeasurement = row.Cell(9).GetString(),

//                        WindingType = ToInt(row.Cell(10)),
//                        ConnectionType = row.Cell(11).GetString()?.Trim(),
//                        StatorLobby = row.Cell(12).GetString()?.Trim(),

//                        CoilGroupWeight = ToDecimal(row.Cell(13)),
//                        TotalWireWeight = ToDecimal(row.Cell(14)),

//                        PhaseSize = row.Cell(15).GetString()?.Trim(),
//                        Amperes = ToDecimal(row.Cell(16)),

//                        WindingDate = ToDate(row.Cell(17)),
//                        GpDc = row.Cell(18).GetString()?.Trim(),

//                        CreatedOn = DateTime.Now,
//                        IsActive = true


//                    };

//                    machines.Add(entity);
//                }

//                if (!machines.Any())
//                    return CommandResult.Fail("No valid records found in Excel.");

//                return await _repository.BulkInsertAsync(machines);
//            }
//            catch (Exception ex)
//            {
//                return CommandResult.Fail(ex.Message);
//            }
//        }

//        // SAFE PARSERS

//        private static int ToInt(IXLCell cell)
//        {
//            if (int.TryParse(cell.GetString(), out var value))
//                return value;

//            return 0;
//        }

//        private static decimal ToDecimal(IXLCell cell)
//        {
//            if (decimal.TryParse(cell.GetString(), out var value))
//                return value;

//            return 0;
//        }

//        private static DateTime ToDate(IXLCell cell)
//        {
//            if (cell.DataType == XLDataType.DateTime)
//                return cell.GetDateTime();

//            if (DateTime.TryParse(cell.GetString(), out var date))
//                return date;

//            return DateTime.MinValue;
//        }
//    }
//}



using MediatR;
using ClosedXML.Excel;
using PrashantApi.Application.Interfaces.ItemMaster;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.ItemMaster.Commands
{
    public class ImportItemMasterExcelHandler
        : IRequestHandler<ImportItemMasterExcelCommand, CommandResult>
    {
        private readonly IItemMasterRepository _repository;

        public ImportItemMasterExcelHandler(IItemMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(
            ImportItemMasterExcelCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var items = new List<ItemMasterModel>();

                using var stream = new MemoryStream();
                await request.File.CopyToAsync(stream, cancellationToken);
                stream.Position = 0;

                using var workbook = new XLWorkbook(stream);
                var worksheet = workbook.Worksheet(1);

                foreach (var row in worksheet.RowsUsed().Skip(1)) // Skip header
                {
                    var entity = new ItemMasterModel
                    {
                        ItemCode = row.Cell(1).GetString().Trim(),
                        ItemName = row.Cell(2).GetString().Trim(),
                        CategoryId = ToInt(row.Cell(3)),
                        PerUnitPrice = ToDecimal(row.Cell(4)),
                        HsnNo = row.Cell(5).GetString().Trim(),
                        AvailableStock = (int)ToDecimal(row.Cell(6)),
                        CreatedOn = DateTime.Now,
                        IsActive = true
                    };

                    // Skip empty rows
                    if (string.IsNullOrWhiteSpace(entity.ItemCode))
                        continue;

                    items.Add(entity);
                }

                if (!items.Any())
                    return CommandResult.Fail("No valid records found in Excel.");

                return await _repository.BulkInsertAsync(items);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

        // SAFE PARSERS

        private static int ToInt(IXLCell cell)
        {
            if (int.TryParse(cell.GetString(), out var value))
                return value;

            return 0;
        }

        private static decimal ToDecimal(IXLCell cell)
        {
            if (decimal.TryParse(cell.GetString(), out var value))
                return value;

            return 0;
        }
    }
}
