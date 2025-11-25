using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.Dashboard;

namespace PrashantApi.Application.Interfaces.Dashboard.Mapping
{
    public class DashboardProfile : Profile
    {
        public DashboardProfile()
        {
            CreateMap<MonthlySalesDto, MonthlySalesDto>().ReverseMap();
            CreateMap<OrderDistributionDto, OrderDistributionDto>().ReverseMap();
            CreateMap<DashboardStatsDto, DashboardStatsDto>().ReverseMap();
            CreateMap<DashboardResponseDto, DashboardResponseDto>().ReverseMap();
        }
    }
}

