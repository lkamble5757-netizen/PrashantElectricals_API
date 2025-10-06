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
    public class EstimateProfile : Profile
    {
        public EstimateProfile()
        {
            CreateMap<AddEstimateCommand, EstimateDto>();
            CreateMap<UpdateEstimateCommand, EstimateDto>();
            CreateMap<EstimateDto, EstimateModel>();
            CreateMap<EstimateModel, EstimateDto>();
        }
    }
}
