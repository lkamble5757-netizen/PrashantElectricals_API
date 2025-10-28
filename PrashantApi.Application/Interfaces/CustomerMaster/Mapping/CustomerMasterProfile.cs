using AutoMapper;
using PrashantApi.Application.DTOs.BranchMaster;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.Feature.BranchMaster.Commands;
using PrashantApi.Application.Feature.CustomerMaster.Commands;
using PrashantApi.Domain.Entities.BranchMaster;
using PrashantApi.Domain.Entities.CustomerMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.CustomerMaster.Mapping
{
    public class CustomerMasterProfile : Profile
    {
        public CustomerMasterProfile()
        {
            CreateMap<CustomerMasterDto, CustomerMasterModel>().ReverseMap();
            CreateMap<AddCustomerMasterCommand, CustomerMasterDto>();
            CreateMap<UpdateCustomerMasterCommand, CustomerMasterDto>();
            CreateMap<CustomerMasterModel, CustomerMasterDto>().ReverseMap();
        }
    }
}