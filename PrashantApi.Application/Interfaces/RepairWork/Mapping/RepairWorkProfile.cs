using AutoMapper;
using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.DTOs.RepairWork;
using PrashantApi.Application.Feature.Estimate.Commands;
using PrashantApi.Application.Feature.RepairWork.Commands;
using PrashantApi.Domain.Entities.Estimate;
using PrashantApi.Domain.Entities.RepairWork;

namespace PrashantApi.Application.Interfaces.RepairWork.Mapping
{
    public class RepairWorkProfile : Profile
    {
        public RepairWorkProfile()
        {
            CreateMap<AddRepairWorkCommand, RepairWorkDto>();
            CreateMap<UpdateRepairWorkCommand, RepairWorkDto>();

            CreateMap<RepairWorkDto, RepairWorkModel>();
            CreateMap<RepairWorkItemDto, RepairWorkItemModel>();

            CreateMap<RepairWorkModel, RepairWorkDto>();
            CreateMap<RepairWorkItemModel, RepairWorkItemDto>();
        }
       
    }
}
