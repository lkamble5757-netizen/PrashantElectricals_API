using AutoMapper;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.DTOs.MachineMaster;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantApi.Application.Feature.MachineMaster.Commands;
using PrashantApi.Domain.Entities.MachineMaster;
using PrashantEle.API.PrashantEle.Domain.DTO.MenuDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.MachineMaster.Mapping
{
    public class MachineMasterProfile : Profile
    {
        public MachineMasterProfile()
        {
            CreateMap<AddMachineMasterCommand, MachineMasterDto>();
            CreateMap<UpdateMachineMasterCommand, MachineMasterDto>();

            CreateMap<MachineMasterDto, MachineMasterModel>();
            CreateMap<MachineMasterModel, MachineMasterDto>();
        }
    }
}