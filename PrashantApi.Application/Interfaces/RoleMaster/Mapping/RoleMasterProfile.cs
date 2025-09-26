using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.RoleMaster;
using PrashantApi.Application.Feature.RoleMaster.Commands;
using PrashantApi.Domain.Entities.RoleMaster;

namespace PrashantApi.Application.Interfaces.RoleMaster
{
    public class RoleMasterProfile : Profile
    {
        public RoleMasterProfile()
        {
            CreateMap<AddRoleMasterCommand, RoleMasterDto>();
            CreateMap<UpdateRoleMasterCommand, RoleMasterDto>();

            CreateMap<RoleMasterDto, RoleMasterModel>();
            CreateMap<RoleMasterModel, RoleMasterDto>();
        }
    }
}
