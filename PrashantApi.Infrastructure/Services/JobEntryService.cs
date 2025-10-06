using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.JobEntry;
using PrashantApi.Domain.Entities.JobEntry;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Infrastructure.Services
{
    public class JobEntryService(IJobEntryRepository repository, IMapper mapper) : IJobEntryService
    {
        private readonly IJobEntryRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> AddAsync(JobEntryDto dto)
        {
            var entity = _mapper.Map<JobEntryModel>(dto);
            entity.CreatedOn = DateTime.Now;
            return await _repository.AddAsync(entity);
        }

        public async Task<CommandResult> UpdateAsync(JobEntryDto dto)
        {
            var entity = _mapper.Map<JobEntryModel>(dto);
            entity.ModifiedOn = DateTime.Now;
            return await _repository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<JobEntryDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<JobEntryDto>>(entities);
        }

        public async Task<IEnumerable<JobEntryDto>> GetByIdAsync(int id)
        {
            var entities = await _repository.GetByIdAsync(id);
            return _mapper.Map<IEnumerable<JobEntryDto>>(entities);
        }
    }
}
