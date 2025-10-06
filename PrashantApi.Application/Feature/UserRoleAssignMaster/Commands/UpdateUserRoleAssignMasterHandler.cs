using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.UserRoleAssignMaster;
using PrashantApi.Application.Interfaces;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.UserRoleAssignMaster.Commands
{
    public class UpdateUserRoleAssignMasterHandler(IUserRoleAssignMasterService service, IMapper mapper)
        : IRequestHandler<UpdateUserRoleAssignMasterCommand> 
    {
        private readonly IUserRoleAssignMasterService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(UpdateUserRoleAssignMasterCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<UserRoleAssignMasterDto>(request);
            await _service.UpdateAsync(dto);
        }
    }
}
