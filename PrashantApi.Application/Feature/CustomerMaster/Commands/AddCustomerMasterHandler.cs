using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.CustomerMaster;
using PrashantApi.Domain.Entities.CustomerMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.CustomerMaster.Commands
{
    public class AddCustomerMasterHandler(ICustomerMasterRepository repository, IMapper mapper)
        : IRequestHandler<AddCustomerMasterCommand, CommandResult>
    {
        private readonly ICustomerMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> Handle(AddCustomerMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<CustomerMasterModel>(request.Customer);
                entity.CreatedOn = DateTime.Now;
                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding Customer: {ex.Message}");
            }
        }
    }
}

