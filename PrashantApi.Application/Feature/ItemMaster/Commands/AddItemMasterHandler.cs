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

namespace PrashantApi.Application.Feature.ItemMaster.Handlers
{
    public class AddItemMasterHandler : IRequestHandler<AddItemMasterCommand, int>
    {
        private readonly IItemMasterService _service;
        private readonly IMapper _mapper;

        public AddItemMasterHandler(IItemMasterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddItemMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = _mapper.Map<ItemMasterDto>(request);
                return await _service.AddAsync(dto);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
