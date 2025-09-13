using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Feature.ItemMaster.Queries;
using PrashantApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.ItemMaster.Handlers
{
    public class GetAllItemMasterHandler(IItemMasterService service, IMapper mapper) : IRequestHandler<GetAllItemMasterQuery, List<ItemMasterDto>>
    {
        private readonly IItemMasterService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ItemMasterDto>> Handle(GetAllItemMasterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _service.GetAllAsync();
                return entities;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

