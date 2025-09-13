using AutoMapper;
 using PrashantEle.API.PrashantEle.Domain.DTO.MenuDetail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrashantApi.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Example mappings – adapt as needed
        CreateMap<MenuDetailDTO, MenuDetailDTO>(); // identity map (placeholder)
        CreateMap<MenuList, MenuList>();           // identity map (placeholder)

        // Add real mappings between DB DTOs -> API models if you introduce view models later
    }
}
