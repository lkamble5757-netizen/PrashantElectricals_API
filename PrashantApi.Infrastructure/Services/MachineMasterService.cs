using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.MachineMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.MachineMaster;
using PrashantApi.Domain.Entities.MachineMaster;

namespace PrashantApi.Infrastructure.Services
{
    public class MachineMasterService(IMachineMasterRepository repository, IMapper mapper) : IMachineMasterService
    {
        private readonly IMachineMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<int> AddAsync(MachineMasterDto dto)
        {
            var entity = _mapper.Map<MachineMasterModel>(dto);
            entity.CreatedOn = DateTime.Now;
            return await _repository.AddAsync(entity);
        }

        public async Task<int> UpdateAsync(MachineMasterDto dto)
        {
            var entity = _mapper.Map<MachineMasterModel>(dto);
            entity.ModifiedOn = DateTime.Now;
            return await _repository.UpdateAsync(entity);
        }

        public async Task<List<MachineMasterDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<MachineMasterDto>>(entities);
        }

        public async Task<MachineMasterDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MachineMasterDto>(entity);
        }
    }
}

