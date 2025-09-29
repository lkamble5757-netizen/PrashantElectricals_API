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
    public class AddUserRoleAssignMasterHandler
        : IRequestHandler<AddUserRoleAssignMasterCommand> 
    {
        private readonly IUserRoleAssignMasterService _service;
        private readonly IMapper _mapper;

        public AddUserRoleAssignMasterHandler(IUserRoleAssignMasterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Handle(AddUserRoleAssignMasterCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<UserRoleAssignMasterDto>(request);
            await _service.AddAsync(dto);
        }
    }
}
