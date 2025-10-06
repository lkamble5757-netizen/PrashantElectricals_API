using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.Estimate.Commands
{
    public class AddEstimateCommand : IRequest<CommandResult>
    {
        public string JobNo { get; set; } = string.Empty;
        public DateTime EstimateDate { get; set; }
        public string EstimatedUser { get; set; } = string.Empty;
        public string? Remarks { get; set; }
        public decimal EstimatedParts { get; set; }
        public decimal EstimatedLabour { get; set; }
        public decimal TransportCharges { get; set; }
        public decimal TotalEstimate { get; set; }
        public bool IsApproved { get; set; } = false;
        public DateTime? ApprovalDate { get; set; }
        public string? ApprovedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public int? CreatedBy { get; set; }
    }
}
