using AutoMapper;
using MediatR;
using PrashantApi.Application.Interfaces.PurchaseOrder;
using PrashantApi.Domain.Entities.PurchaseOrder;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.PurchaseOrder.Commands
{
    public class UpdatePurchaseOrderHandler: IRequestHandler<UpdatePurchaseOrderCommand, CommandResult>
    {
        private readonly IPurchaseOrderRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePurchaseOrderHandler(IPurchaseOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdatePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PurchaseOrderMasterModel>(request.PurchaseOrder);
            return await _repository.UpdateAsync(entity);
        }
    }

}
