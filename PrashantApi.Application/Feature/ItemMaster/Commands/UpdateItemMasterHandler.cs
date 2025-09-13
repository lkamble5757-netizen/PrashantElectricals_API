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

namespace PrashantApi.Application.Feature.ItemMaster.Commands
{
    public class UpdateItemMasterHandler(IItemMasterService service, IMapper mapper) : IRequestHandler<UpdateItemMasterCommand, int>
    {
        private readonly IItemMasterService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(UpdateItemMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = _mapper.Map<ItemMasterDto>(request);
                return await _service.UpdateAsync(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
