using AutoMapper;
using PrashantApi.Application.DTOs.InvoiceMaster;
using PrashantApi.Domain.Entities.InvoiceMaster;

namespace PrashantApi.Application.Interfaces.InvoiceMaster.Mapping
{
    public class InvoiceMasterProfile : Profile
    {
        public InvoiceMasterProfile()
        {
            CreateMap<InvoiceMasterDto, InvoiceMasterModel>();
            //CreateMap<InvoiceJobDetailsDto, InvoiceJobDetailsModel>();
            CreateMap<InvoiceItemDetailsDto, InvoiceItemDetailsModel>();

            CreateMap<InvoiceMasterModel, InvoiceMasterDto>();
            //CreateMap<InvoiceJobDetailsModel, InvoiceJobDetailsDto>();
            CreateMap<InvoiceItemDetailsModel, InvoiceItemDetailsDto>();
        }
    }
}
