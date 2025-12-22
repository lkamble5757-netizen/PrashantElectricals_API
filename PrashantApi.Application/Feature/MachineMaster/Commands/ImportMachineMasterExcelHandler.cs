using ClosedXML.Excel;
using MediatR;
using PrashantApi.Application.Interfaces.MachineMaster;
using PrashantApi.Domain.Entities.MachineMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.MachineMaster.Commands
{
    public class ImportMachineMasterExcelHandler
        : IRequestHandler<ImportMachineMasterExcelCommand, CommandResult>
    {
        private readonly IMachineMasterRepository _repository;

        public ImportMachineMasterExcelHandler(IMachineMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(
            ImportMachineMasterExcelCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var machines = new List<MachineMasterModel>();

                using var stream = new MemoryStream();
                await request.File.CopyToAsync(stream, cancellationToken);
                stream.Position = 0;

                using var workbook = new XLWorkbook(stream);
                var worksheet = workbook.Worksheet(1);

                foreach (var row in worksheet.RowsUsed().Skip(1)) // skip header
                {
                    var entity = new MachineMasterModel
                    {
                        BrandName = row.Cell(1).GetString().Trim(),

                        HpKw = ToInt(row.Cell(2)),
                        Slot = ToInt(row.Cell(3)),
                        RPM = ToInt(row.Cell(4)),

                        Pitch = row.Cell(5).GetString()?.Trim(),
                        Gauge = row.Cell(6).GetString()?.Trim(),
                        AlterGauge = row.Cell(7).GetString()?.Trim(),

                        Turn = ToInt(row.Cell(8)),
                        CoilMeasurement = row.Cell(9).GetString(),

                        WindingType = ToInt(row.Cell(10)),
                        ConnectionType = row.Cell(11).GetString()?.Trim(),
                        StatorLobby = row.Cell(12).GetString()?.Trim(),

                        CoilGroupWeight = ToDecimal(row.Cell(13)),
                        TotalWireWeight = ToDecimal(row.Cell(14)),

                        PhaseSize = row.Cell(15).GetString()?.Trim(),
                        Amperes = ToDecimal(row.Cell(16)),

                        WindingDate = ToDate(row.Cell(17)),
                        GpDc = row.Cell(18).GetString()?.Trim(),

                        CreatedOn = DateTime.Now,
                        IsActive = true


                    };

                    machines.Add(entity);
                }

                if (!machines.Any())
                    return CommandResult.Fail("No valid records found in Excel.");

                return await _repository.BulkInsertAsync(machines);
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

        private static DateTime ToDate(IXLCell cell)
        {
            if (cell.DataType == XLDataType.DateTime)
                return cell.GetDateTime();

            if (DateTime.TryParse(cell.GetString(), out var date))
                return date;

            return DateTime.MinValue;
        }
    }
}
