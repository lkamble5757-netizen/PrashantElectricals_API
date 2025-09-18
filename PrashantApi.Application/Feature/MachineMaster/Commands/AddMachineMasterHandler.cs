using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.MachineMaster;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Application.Feature.MachineMaster.Commands
{
    public class AddMachineMasterHandler(IMachineMasterService service, IMapper mapper)
        : IRequestHandler<AddMachineMasterCommand, int>
    {
        private readonly IMachineMasterService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(AddMachineMasterCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<MachineMasterDto>(request);
            return await _service.AddAsync(dto);
        }
    }
}

