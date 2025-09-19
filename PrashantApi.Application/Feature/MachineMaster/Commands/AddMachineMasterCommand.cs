using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PrashantApi.Application.Feature.MachineMaster.Commands
{
    public class AddMachineMasterCommand : IRequest<int>
    {
        public string BrandName { get; set; } = string.Empty;
        public int? HpKw { get; set; }
        public int? Slot { get; set; }
        public int? RPM { get; set; }
        public string? Pitch { get; set; }
        public string? Gauge { get; set; }
        public string? AlterGauge { get; set; }
        public int? Turn { get; set; }
        public string? CoilMeasurement { get; set; }
        public int? WindingType { get; set; }
        public string? ConnectionType { get; set; }
        public string? StatorLobby { get; set; }
        public decimal? CoilGroupWeight { get; set; }
        public decimal? TotalWireWeight { get; set; }
        public string? PhaseSize { get; set; }
        public decimal? Amperes { get; set; }
        public DateTime? WindingDate { get; set; }
        public string? GpDc { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}

