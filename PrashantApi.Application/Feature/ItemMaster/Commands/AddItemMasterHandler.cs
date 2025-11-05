using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.BranchMaster;
using PrashantApi.Application.Interfaces.ItemMaster;
using PrashantApi.Domain.Entities.BranchMaster;
using PrashantApi.Domain.Entities.ItemMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.ItemMaster.Commands
{
    public class AddItemMasterHandler : IRequestHandler<AddItemMasterCommand, CommandResult>
    {
        private readonly IItemMasterRepository _repository;
        private readonly IMapper _mapper;

        public AddItemMasterHandler(IItemMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(AddItemMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<ItemMasterModel>(request.ItemMaster);
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