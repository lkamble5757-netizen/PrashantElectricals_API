using AutoMapper;
using PrashantApi.Application.DTOs.StockUpdateMaster;
using PrashantApi.Domain.Entities.StockUpdateMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.StockUpdateMaster.Mapping
{
    public class StockUpdateProfile : Profile
    {
        public StockUpdateProfile()
        {
            CreateMap<StockUpdateMasterDto, StockUpdateMasterModel>();
            CreateMap<StockUpdateDetailsDto, StockUpdateDetailsModel>();

            CreateMap<StockUpdateMasterModel, StockUpdateMasterDto>();
            CreateMap<StockUpdateDetailsModel, StockUpdateDetailsDto>();
        }
    }

}
