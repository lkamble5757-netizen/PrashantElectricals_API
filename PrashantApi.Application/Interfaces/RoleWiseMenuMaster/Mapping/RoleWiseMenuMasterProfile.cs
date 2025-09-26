using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands;
using PrashantApi.Domain.Entities.RoleWiseMenuMaster;

namespace PrashantApi.Application.Interfaces.RoleWiseMenuMaster.Mapping
{
    public class RoleWiseMenuMasterProfile : Profile
    {
        public RoleWiseMenuMasterProfile()
        {
            CreateMap<AddRoleWiseMenuMasterCommand, RoleWiseMenuMasterDto>();
            CreateMap<UpdateRoleWiseMenuMasterCommand, RoleWiseMenuMasterDto>();

            CreateMap<RoleWiseMenuMasterDto, RoleWiseMenuMasterModel>();
            CreateMap<RoleWiseMenuMasterModel, RoleWiseMenuMasterDto>();
        }
    }
}
