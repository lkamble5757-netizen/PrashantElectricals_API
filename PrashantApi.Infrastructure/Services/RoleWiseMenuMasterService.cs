using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RoleWiseMenuMaster;
using PrashantApi.Domain.Entities.RoleWiseMenuMaster;

namespace PrashantApi.Infrastructure.Services
{
    public class RoleWiseMenuMasterService(IRoleWiseMenuMasterRepository repository, IMapper mapper) : IRoleWiseMenuMasterService
    {
        private readonly IRoleWiseMenuMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task AddAsync(RoleWiseMenuMasterDto dto)
        {
            var entity = _mapper.Map<RoleWiseMenuMasterModel>(dto);
            entity.CreatedOn = DateTime.Now;
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(RoleWiseMenuMasterDto dto)
        {
            var entity = _mapper.Map<RoleWiseMenuMasterModel>(dto);
            entity.ModifiedOn = DateTime.Now;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<dynamic>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<dynamic>>(entities);
        }

        public async Task<List<dynamic>> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id); // ✅ FIXED: Return directly
        }
    }
}
