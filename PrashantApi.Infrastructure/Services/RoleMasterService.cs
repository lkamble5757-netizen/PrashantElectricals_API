using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.RoleMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RoleMaster;
using PrashantApi.Domain.Entities.RoleMaster;

namespace PrashantApi.Infrastructure.Services
{
    public class RoleMasterService(IRoleMasterRepository repository, IMapper mapper) : IRoleMasterService
    {
        private readonly IRoleMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<int> AddAsync(RoleMasterDto dto)
        {
            var entity = _mapper.Map<RoleMasterModel>(dto);
            entity.CreatedOn = DateTime.Now;
            return await _repository.AddAsync(entity);
        }

        public async Task<int> UpdateAsync(RoleMasterDto dto)
        {
            var entity = _mapper.Map<RoleMasterModel>(dto);
            entity.ModifiedOn = DateTime.Now;
            return await _repository.UpdateAsync(entity);
        }

        public async Task<List<RoleMasterDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<RoleMasterDto>>(entities);
        }

        public async Task<RoleMasterDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<RoleMasterDto>(entity);
        }
    }
}
