using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RoleMaster;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Application.Feature.RoleMaster.Commands
{
    public class UpdateRoleMasterHandler(IRoleMasterService service, IMapper mapper)
        : IRequestHandler<UpdateRoleMasterCommand, int>
    {
        private readonly IRoleMasterService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(UpdateRoleMasterCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<RoleMasterDto>(request);
            return await _service.UpdateAsync(dto);
        }
    }
}
