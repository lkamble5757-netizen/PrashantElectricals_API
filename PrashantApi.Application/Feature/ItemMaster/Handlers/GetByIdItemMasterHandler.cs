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

namespace PrashantApi.Application.Feature.ItemMaster.Handlers
{
    public class GetByIdItemMasterHandler : IRequestHandler<GetByIdItemMasterQuery, ItemMasterDto>
    {
        private readonly IItemMasterService _service;
        private readonly IMapper _mapper;

        public GetByIdItemMasterHandler(IItemMasterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ItemMasterDto> Handle(GetByIdItemMasterQuery request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetByIdAsync(request.Id);
            return entity;
        }
    }
}


