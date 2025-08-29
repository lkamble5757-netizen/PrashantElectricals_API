using AutoMapper;
using PrashantApi.Application.DTOs.BranchMaster;
using PrashantApi.Application.Feature.BranchMaster.Commands;
using PrashantApi.Domain.Entities.BranchMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.BranchMaster.Mapping
{
    public class BranchMasterProfile : Profile
    {
        public BranchMasterProfile()
        {
            CreateMap<BranchMasterDto, BranchMasterModel>();
            CreateMap<BranchMasterModel, BranchMasterDto>();

            CreateMap<AddBranchMasterCommand, BranchMasterModel>();

        }
    }
}
