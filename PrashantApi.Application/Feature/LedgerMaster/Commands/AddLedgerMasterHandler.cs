using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.LedgerMaster;
using PrashantApi.Application.Interfaces.LedgerMaster;
using PrashantApi.Domain.Entities.LedgerMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantApi.Application.Common;
using PrashantApi.Infrastructure.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.LedgerMaster.Commands
{
    public class AddLedgerMasterHandler : IRequestHandler<AddLedgerMasterCommand, CommandResult>
    {
        private readonly ILedgerMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddLedgerMasterHandler(ILedgerMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddLedgerMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<LedgerMasterModel>(request.Ledger);

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