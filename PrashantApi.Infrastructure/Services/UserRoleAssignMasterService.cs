using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.UserRoleAssignMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.UserRoleAssignMaster;
using PrashantApi.Domain.Entities.UserRoleAssignMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Infrastructure.Services
{
    public class UserRoleAssignMasterService(IUserRoleAssignMasterRepository repository, IMapper mapper) : IUserRoleAssignMasterService
    {
        private readonly IUserRoleAssignMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> AddAsync(UserRoleAssignMasterDto dto)
        {
            var entity = _mapper.Map<UserRoleAssignMasterModel>(dto);
            entity.CreatedOn = DateTime.Now;
            return await _repository.AddAsync(entity);
        }

        public async Task<CommandResult> UpdateAsync(UserRoleAssignMasterDto dto)
        {
            var entity = _mapper.Map<UserRoleAssignMasterModel>(dto);
            entity.ModifiedOn = DateTime.Now;
            return await _repository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<dynamic>>(entities);
        }

        public async Task<IEnumerable<dynamic>> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
