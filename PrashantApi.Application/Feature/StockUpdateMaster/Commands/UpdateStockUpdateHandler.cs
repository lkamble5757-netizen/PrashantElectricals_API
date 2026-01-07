using AutoMapper;
using MediatR;
using PrashantApi.Application.Interfaces.StockUpdateMaster;
using PrashantApi.Domain.Entities.StockUpdateMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.StockUpdateMaster.Commands
{
    public class UpdateStockUpdateHandler : IRequestHandler<UpdateStockUpdateCommand, CommandResult>
    {
        private readonly IStockUpdateRepository _repository;
        private readonly IMapper _mapper;

        public UpdateStockUpdateHandler(IStockUpdateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateStockUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StockUpdateMasterModel>(request.StockUpdate);
            entity.ModifiedOn = DateTime.Now;

            return await _repository.UpdateAsync(entity);
        }
    }

}
