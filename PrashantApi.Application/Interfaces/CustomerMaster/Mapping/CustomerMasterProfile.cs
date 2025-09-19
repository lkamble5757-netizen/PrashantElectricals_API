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

namespace PrashantApi.Application.Interfaces.BranchMaster.Mapping
{
    public class CustomerMasterProfile : Profile
    {
        public CustomerMasterProfile()
        {
            // CustomerMaster mappings
            CreateMap<CustomerMasterDto, CustomerMasterModel>().ReverseMap();

            CreateMap<AddCustomerMasterCommand, CustomerMasterDto>().ReverseMap();
            CreateMap<UpdateCustomerMasterCommand, CustomerMasterDto>().ReverseMap();

            CreateMap<AddCustomerMasterCommand, CustomerMasterModel>().ReverseMap();
            CreateMap<UpdateCustomerMasterCommand, CustomerMasterModel>().ReverseMap();

        }
    }
}
