using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.Estimate;
using PrashantApi.Domain.Entities.Estimate;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Infrastructure.Services
{
    public class EstimateService(IEstimateRepository repository, IMapper mapper) : IEstimateService
    {
        private readonly IEstimateRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> AddAsync(EstimateDto dto)
        {
            var entity = _mapper.Map<EstimateModel>(dto);
            entity.CreatedOn = DateTime.Now;
            return await _repository.AddAsync(entity);
        }

        public async Task<CommandResult> UpdateAsync(EstimateDto dto)
        {
            var entity = _mapper.Map<EstimateModel>(dto);
            entity.ModifiedOn = DateTime.Now;
            return await _repository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<EstimateDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EstimateDto>>(entities);
        }

        public async Task<IEnumerable<EstimateDto>> GetByIdAsync(int id)
        {
            var entities = await _repository.GetByIdAsync(id);
            return _mapper.Map<IEnumerable<EstimateDto>>(entities);
        }
    }
}
