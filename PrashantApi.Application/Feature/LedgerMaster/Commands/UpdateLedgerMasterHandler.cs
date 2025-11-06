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

namespace PrashantApi.Application.Feature.LedgerMaster.Commands
{
    public class UpdateLedgerMasterHandler(ILedgerMasterRepository repository, IMapper mapper)
        : IRequestHandler<UpdateLedgerMasterCommand, CommandResult>
    {
        private readonly ILedgerMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> Handle(UpdateLedgerMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<LedgerMasterModel>(request.Ledger);
                entity.ModifiedOn = DateTime.Now;
                var result = await _repository.UpdateAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating Ledger: {ex.Message}");
            }
        }
    }
}

