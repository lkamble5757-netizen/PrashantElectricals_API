using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.Feature.Estimate.Commands;
using PrashantApi.Domain.Entities.Estimate;

namespace PrashantApi.Application.Interfaces.Estimate.Mapping
{
    public class EstimateMasterProfile : Profile
    {
        public EstimateMasterProfile()
        {
            CreateMap<AddEstimateMasterCommand, EstimateMasterDto>();
            CreateMap<UpdateEstimateMasterCommand, EstimateMasterDto>();
            CreateMap<EstimateMasterDto, EstimateMasterModel>();
            CreateMap<EstimateMasterModel, EstimateMasterDto>();

            CreateMap<EstimatedPartDetailsDto, EstimatedPartDetailsModel>();
            CreateMap<EstimatedPartDetailsModel, EstimatedPartDetailsDto>();
        }
    }
}
