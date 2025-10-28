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
    public class UpdateCustomerMasterHandler(ICustomerMasterRepository repository, IMapper mapper)
        : IRequestHandler<UpdateCustomerMasterCommand, CommandResult>
    {
        private readonly ICustomerMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> Handle(UpdateCustomerMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<CustomerMasterModel>(request.Customer);
                entity.ModifiedOn = DateTime.Now;
                var result = await _repository.UpdateAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating Customer: {ex.Message}");
            }
        }
    }
}

