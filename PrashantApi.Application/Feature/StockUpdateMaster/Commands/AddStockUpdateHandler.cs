using AutoMapper;
using MediatR;
using PrashantApi.Application.Interfaces.StockUpdateMaster;
using PrashantApi.Domain.Entities.StockUpdateMaster;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.StockUpdateMaster.Commands
{
    public class AddStockUpdateHandler : IRequestHandler<AddStockUpdateCommand, CommandResult>
    {
        private readonly IStockUpdateRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddStockUpdateHandler(IStockUpdateRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddStockUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StockUpdateMasterModel>(request.StockUpdate);

            var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdClaim, out var userId))
                entity.CreatedBy = userId;

            entity.CreatedOn = DateTime.Now;

            return await _repository.AddAsync(entity);
        }
    }

}
