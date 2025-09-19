using AutoMapper;
using PrashantApi.Application.DTOs.BranchMaster;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Feature.BranchMaster.Commands;
using PrashantApi.Application.Feature.CustomerMaster.Commands;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantApi.Domain.Entities.BranchMaster;
using PrashantApi.Domain.Entities.CustomerMaster;
using PrashantEle.API.PrashantEle.Domain.DTO.MenuDetail;
using PrashantApi.Application.Interfaces.BranchMaster.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.BranchMaster.Mapping
{
    public class ItemMasterProfile : Profile
    {
        public ItemMasterProfile()
        {
            // ItemMaster mappings
            CreateMap<MenuDetailDTO, MenuDetailDTO>();
            CreateMap<MenuList, MenuList>();
            CreateMap<ItemMasterDto, ItemMasterDto>();

            CreateMap<AddItemMasterCommand, ItemMasterDto>();
            CreateMap<ItemMasterDto, AddItemMasterCommand>();

            CreateMap<UpdateItemMasterCommand, ItemMasterDto>();
            CreateMap<ItemMasterDto, UpdateItemMasterCommand>();

        }
    }
}

