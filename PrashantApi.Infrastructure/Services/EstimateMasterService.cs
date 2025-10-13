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
    public class EstimateMasterService(IEstimateMasterRepository repository, IMapper mapper) : IEstimateMasterService
    {
        private readonly IEstimateMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> AddAsync(EstimateMasterDto dto) 
        {
            var entity = _mapper.Map<EstimateMasterModel>(dto); 
            return await _repository.AddAsync(entity);
        }

        public async Task<CommandResult> UpdateAsync(EstimateMasterDto dto) 
        {
            var entity = _mapper.Map<EstimateMasterModel>(dto); 
            return await _repository.UpdateAsync(entity);
        }

        public async Task<dynamic> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<dynamic> GetByIdAsync(int id) 
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<dynamic> GetJobNoByCustomerID(int id) 
        {
            return await _repository.GetJobNoByCustomerID(id);
        }
    }

}
