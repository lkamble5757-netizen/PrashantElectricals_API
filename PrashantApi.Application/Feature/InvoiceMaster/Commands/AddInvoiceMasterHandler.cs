using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.InvoiceMaster;
using PrashantApi.Application.Interfaces.InvoiceMaster;
using PrashantApi.Domain.Entities.InvoiceMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace PrashantApi.Application.Feature.InvoiceMaster.Commands
{
    public class AddInvoiceMasterHandler : IRequestHandler<AddInvoiceMasterCommand, CommandResult>
    {
        private readonly IInvoiceMasterRepository _repository;
        private readonly IMapper _mapper;

        public AddInvoiceMasterHandler(IInvoiceMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(AddInvoiceMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<InvoiceMasterModel>(request.InvoiceMaster);
                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding InvoiceMaster: {ex.Message}");
            }
        }
    }
}
