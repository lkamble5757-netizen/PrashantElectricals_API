using PrashantApi.Application.DTOs.ReferenceDataMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.ReferenceDataMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Services
{
    public class ReferenceDataMasterService : IReferenceDataMasterService
    {
        private readonly IReferenceDataMasterRepository _repository;

        public ReferenceDataMasterService(IReferenceDataMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RoleDto>> GetRoleNamesAsync()
        {
            return await _repository.GetRoleNamesAsync();
        }

        public async Task<List<MenuDto>> GetMenuNamesAsync()
        {
            return await _repository.GetMenuNamesAsync();
        }

        public async Task<List<UserDto>> GetUserNamesAsync()
        {
            return await _repository.GetUserNamesAsync();
        }
    }
}
