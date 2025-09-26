using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands
{
    public class UpdateRoleWiseMenuMasterHandler(IRoleWiseMenuMasterService service, IMapper mapper)
    : IRequestHandler<UpdateRoleWiseMenuMasterCommand>
    {
        private readonly IRoleWiseMenuMasterService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(UpdateRoleWiseMenuMasterCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<RoleWiseMenuMasterDto>(request);
            await _service.UpdateAsync(dto);
        }
    }
}
