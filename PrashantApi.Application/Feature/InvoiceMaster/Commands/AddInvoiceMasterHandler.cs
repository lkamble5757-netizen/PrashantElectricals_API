using AutoMapper;
using Dapper;
using MediatR;
using PrashantApi.Application.DTOs.InvoiceMaster;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantApi.Application.Interfaces.InvoiceMaster;
using PrashantApi.Domain.Entities.InvoiceMaster;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using PrashantApi.Application.Common;


namespace PrashantApi.Application.Feature.InvoiceMaster.Commands
{
    public class AddInvoiceMasterHandler : IRequestHandler<AddInvoiceMasterCommand, CommandResult>
    {
        private readonly IInvoiceMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddInvoiceMasterHandler(IInvoiceMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddInvoiceMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<InvoiceMasterModel>(request.InvoiceMaster);

               
                var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.Id)?.Value;
                if (int.TryParse(userIdClaim, out var userId))
                    entity.CreatedBy = userId;

                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                //return CommandResult.Fail($"Error adding InvoiceMaster: {ex.Message}");
                return CommandResult.Fail(ex.Message);
            }
        }
    }
}
