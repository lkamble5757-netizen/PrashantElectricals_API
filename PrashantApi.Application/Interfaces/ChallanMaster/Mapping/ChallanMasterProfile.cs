using AutoMapper;
using PrashantApi.Application.DTOs.ChallanMaster;
using PrashantApi.Domain.Entities.ChallanMaster;

namespace PrashantApi.Application.Feature.ChallanMaster.Mapping
{
    public class ChallanMasterProfile : Profile
    {
        public ChallanMasterProfile()
        {
            CreateMap<ChallanMasterDto, ChallanMasterModel>().ReverseMap();
            CreateMap<ChallanDetailsDto, ChallanDetailsModel>().ReverseMap();
        }
    }
}
