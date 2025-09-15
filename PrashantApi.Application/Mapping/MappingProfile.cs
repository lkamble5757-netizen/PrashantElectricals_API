using AutoMapper;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Feature.CustomerMaster.Commands;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantEle.API.PrashantEle.Domain.DTO.MenuDetail;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PrashantApi.Domain.Entities.CustomerMaster;        // ✅ Added


namespace PrashantApi.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // ItemMaster mappings
        CreateMap<MenuDetailDTO, MenuDetailDTO>(); 
        CreateMap<MenuList, MenuList>();    
        CreateMap<ItemMasterDto, ItemMasterDto>();

        CreateMap<AddItemMasterCommand, ItemMasterDto>();
        CreateMap<ItemMasterDto, AddItemMasterCommand>();

        CreateMap<UpdateItemMasterCommand, ItemMasterDto>();
        CreateMap<ItemMasterDto, UpdateItemMasterCommand>();


        // CustomerMaster mappings
        CreateMap<CustomerMasterDto, CustomerMasterModel>().ReverseMap();

        CreateMap<AddCustomerMasterCommand, CustomerMasterDto>().ReverseMap();
        CreateMap<UpdateCustomerMasterCommand, CustomerMasterDto>().ReverseMap();

        CreateMap<AddCustomerMasterCommand, CustomerMasterModel>().ReverseMap();
        CreateMap<UpdateCustomerMasterCommand, CustomerMasterModel>().ReverseMap();
    }

}