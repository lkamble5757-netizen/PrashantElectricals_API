using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.MachineMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.MachineMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.MachineMaster.Commands
{
    public class UpdateMachineMasterHandler(IMachineMasterService service, IMapper mapper)
        : IRequestHandler<UpdateMachineMasterCommand, int>
    {
        private readonly IMachineMasterService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(UpdateMachineMasterCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<MachineMasterDto>(request);
            return await _service.UpdateAsync(dto);
        }
    }
}

