using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.UserRoleAssignMaster;
using PrashantApi.Application.Feature.UserRoleAssignMaster.Commands;
using PrashantApi.Domain.Entities.UserRoleAssignMaster;

namespace PrashantApi.Application.Interfaces.UserRoleAssignMaster.Mapping
{
    public class UserRoleAssignMasterProfile : Profile
    {
        public UserRoleAssignMasterProfile()
        {
            CreateMap<AddUserRoleAssignMasterCommand, UserRoleAssignMasterDto>();
            CreateMap<UpdateUserRoleAssignMasterCommand, UserRoleAssignMasterDto>();

            CreateMap<UserRoleAssignMasterDto, UserRoleAssignMasterModel>();
            CreateMap<UserRoleAssignMasterModel, UserRoleAssignMasterDto>();
        }
    }
}
