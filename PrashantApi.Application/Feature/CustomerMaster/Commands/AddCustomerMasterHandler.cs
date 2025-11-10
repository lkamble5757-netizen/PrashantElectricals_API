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
using PrashantApi.Infrastructure.Common;
using PrashantApi.Application.Common;

namespace PrashantApi.Application.Feature.CustomerMaster.Commands
{
    public class AddCustomerMasterHandler : IRequestHandler<AddCustomerMasterCommand, CommandResult>
    {
        private readonly ICustomerMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddCustomerMasterHandler( ICustomerMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddCustomerMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<CustomerMasterModel>(request.Customer);

                var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.Id)?.Value;
                if (int.TryParse(userIdClaim, out var userId))
                    entity.CreatedBy = userId;

                entity.CreatedOn = DateTime.Now;

                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }
    }
}