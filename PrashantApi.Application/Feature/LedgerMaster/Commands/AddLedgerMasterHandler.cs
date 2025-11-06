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
    public class AddLedgerMasterHandler(ILedgerMasterRepository repository, IMapper mapper)
        : IRequestHandler<AddLedgerMasterCommand, CommandResult>
    {
        private readonly ILedgerMasterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> Handle(AddLedgerMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<LedgerMasterModel>(request.Ledger);
                entity.CreatedOn = DateTime.Now;
                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding Ledger: {ex.Message}");
            }
        }
    }
}

