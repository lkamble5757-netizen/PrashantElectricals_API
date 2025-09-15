using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.CustomerMaster;
using PrashantApi.Domain.Entities.CustomerMaster;

namespace PrashantApi.Infrastructure.Services
{
    public class CustomerMasterService(ICustomerMasterRepository repository, IMapper mapper) : ICustomerMasterService
    {
        private readonly ICustomerMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<int> AddAsync(CustomerMasterDto dto)
        {
            var entity = _mapper.Map<CustomerMasterModel>(dto);
            entity.CreatedOn = DateTime.Now;
            return await _repository.AddAsync(entity);
        }

        public async Task<int> UpdateAsync(CustomerMasterDto dto)
        {
            var entity = _mapper.Map<CustomerMasterModel>(dto);
            entity.ModifiedOn = DateTime.Now;
            return await _repository.UpdateAsync(entity);
        }

        public async Task<List<CustomerMasterDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<CustomerMasterDto>>(entities);
        }

        public async Task<CustomerMasterDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CustomerMasterDto>(entity);
        }
    }
}
