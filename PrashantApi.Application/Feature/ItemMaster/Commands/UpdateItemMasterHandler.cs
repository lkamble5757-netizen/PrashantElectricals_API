using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PrashantApi.Application.Interfaces.ItemMaster;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.ItemMaster.Commands
{
    public class UpdateItemMasterHandler : IRequestHandler<UpdateItemMasterCommand, CommandResult>
    {
        private readonly IItemMasterRepository _repository;
        private readonly IMapper _mapper;

        public UpdateItemMasterHandler(IItemMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateItemMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<ItemMasterModel>(request.ItemMaster);
                var result = await _repository.UpdateAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating ItemMaster: {ex.Message}");
            }
        }
    }
}
