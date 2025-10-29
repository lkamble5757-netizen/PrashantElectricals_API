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
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces.ItemMaster.Mapping
{
    public class ItemMasterProfile : Profile
    {
        public ItemMasterProfile()
        {
            CreateMap<AddItemMasterCommand, ItemMasterDto>();
            CreateMap<UpdateItemMasterCommand, ItemMasterDto>();
            CreateMap<ItemMasterDto, ItemMasterModel>();
            CreateMap<ItemMasterModel, ItemMasterDto>();
        }
    }
}