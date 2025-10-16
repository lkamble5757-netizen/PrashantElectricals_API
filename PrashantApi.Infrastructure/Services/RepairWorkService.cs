using AutoMapper;
using AutoMapper;
using PrashantApi.Application.DTOs.RepairWork;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RepairWork;
using PrashantApi.Domain.Entities.RepairWork;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Services
{
    public class RepairWorkService : IRepairWorkService
    {
        private readonly IRepairWorkRepository _repository;
        private readonly IMapper _mapper;

        public RepairWorkService(IRepairWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> AddAsync(RepairWorkDto dto)
        {
            var entity = _mapper.Map<RepairWorkModel>(dto);
            entity.CreatedOn = DateTime.Now;
            return await _repository.AddAsync(entity);
        }

        public async Task<CommandResult> UpdateAsync(RepairWorkDto dto)
        {
            var entity = _mapper.Map<RepairWorkModel>(dto);
            entity.ModifiedOn = DateTime.Now;
            return await _repository.UpdateAsync(entity);
        }

        public async Task<List<RepairWorkDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<RepairWorkDto>>(entities);
        }

        public async Task<RepairWorkDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<RepairWorkDto>(entity);
        }
    }
}
