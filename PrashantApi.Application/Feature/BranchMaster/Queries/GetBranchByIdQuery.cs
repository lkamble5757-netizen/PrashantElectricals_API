using MediatR;
using PrashantApi.Application.DTOs.BranchMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.BranchMaster.Queries
{
    public class GetBranchByIdQuery : IRequest<BranchMasterDto?>
    {
        public int Id { get; set; }
        public GetBranchByIdQuery(int id) => Id = id;
    }
}
