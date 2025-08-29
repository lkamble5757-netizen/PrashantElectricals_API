using MediatR;
using PrashantApi.Application.DTOs.BranchMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.BranchMaster.Commands
{

    public class AddBranchMasterCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
    }
}
