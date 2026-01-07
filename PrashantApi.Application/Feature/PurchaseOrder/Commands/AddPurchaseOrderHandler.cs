using AutoMapper;
using MediatR;
using PrashantApi.Application.Interfaces.PurchaseOrder;
using PrashantApi.Domain.Entities.PurchaseOrder;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.PurchaseOrder.Commands
{
    public class AddPurchaseOrderHandler: IRequestHandler<AddPurchaseOrderCommand, CommandResult>
    {
        private readonly IPurchaseOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddPurchaseOrderHandler(IPurchaseOrderRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddPurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PurchaseOrderMasterModel>(request.PurchaseOrder);

            var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (int.TryParse(userIdClaim, out var userId))
                entity.CreatedBy = userId;


            return await _repository.AddAsync(entity);
        }
    }

}


