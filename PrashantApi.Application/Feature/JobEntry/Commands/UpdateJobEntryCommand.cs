using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.JobEntry.Commands
{
    public class UpdateJobEntryCommand : IRequest<CommandResult>
    {
        public int ID { get; set; }
        public string JobNo { get; set; } = string.Empty;
        public DateTime DateReceived { get; set; }
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? MachineMake { get; set; }
        public string? Model { get; set; }
        public string? HP { get; set; }
        public string? KW { get; set; }
        public string? RPM { get; set; }
        public string? SerialNo { get; set; }
        public string? IssueReported { get; set; }
        public string? TechnicianAssigned { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public int Status { get; set; }
        public string? Attachments { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
