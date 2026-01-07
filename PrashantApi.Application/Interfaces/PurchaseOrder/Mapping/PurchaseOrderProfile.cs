using AutoMapper;
using PrashantApi.Application.DTOs.PurchaseOrder;
using PrashantApi.Domain.Entities.PurchaseOrder;

namespace PrashantApi.Application.Interfaces.PurchaseOrder.Mapping
{
    public class PurchaseOrderProfile : Profile
    {
        public PurchaseOrderProfile()
        {
            CreateMap<PurchaseOrderMasterDto, PurchaseOrderMasterModel>();
            CreateMap<PurchaseOrderDetailsDto, PurchaseOrderDetailsModel>();

            CreateMap<PurchaseOrderMasterModel, PurchaseOrderMasterDto>();
            CreateMap<PurchaseOrderDetailsModel, PurchaseOrderDetailsDto>();
        }
    }
}
