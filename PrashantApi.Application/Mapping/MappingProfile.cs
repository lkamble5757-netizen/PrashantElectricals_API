using AutoMapper;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantEle.API.PrashantEle.Domain.DTO.MenuDetail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrashantApi.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Example mappings – adapt as needed
        CreateMap<MenuDetailDTO, MenuDetailDTO>(); // identity map (placeholder)
        CreateMap<MenuList, MenuList>();           // identity map (placeholder)
        CreateMap<ItemMasterDto, ItemMasterDto>();

        CreateMap<AddItemMasterCommand, ItemMasterDto>();
        CreateMap<ItemMasterDto, AddItemMasterCommand>();

        CreateMap<UpdateItemMasterCommand, ItemMasterDto>();
        CreateMap<ItemMasterDto, UpdateItemMasterCommand>();


        // Add real mappings between DB DTOs -> API models if you introduce view models later
    }
}
