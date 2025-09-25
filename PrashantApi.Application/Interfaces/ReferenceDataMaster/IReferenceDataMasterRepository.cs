using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.ReferenceDataMaster;


namespace PrashantApi.Application.Interfaces.ReferenceDataMaster
{
    public interface IReferenceDataMasterRepository
    {
        Task<List<RoleDto>> GetRoleNamesAsync();
        Task<List<MenuDto>> GetMenuNamesAsync();
        Task<List<UserDto>> GetUserNamesAsync();
    }
}
