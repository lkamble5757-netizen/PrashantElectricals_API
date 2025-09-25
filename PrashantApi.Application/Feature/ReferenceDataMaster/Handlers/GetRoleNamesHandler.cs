using MediatR;
using PrashantApi.Application.DTOs.ReferenceDataMaster;
using PrashantApi.Application.Feature.ReferenceDataMaster.Queries;
using PrashantApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.ReferenceDataMaster.Handlers
{
    public class GetRoleNamesHandler(IReferenceDataMasterService service)
        : IRequestHandler<GetRoleNamesQuery, List<RoleDto>>
    {
        private readonly IReferenceDataMasterService _service = service;

        public async Task<List<RoleDto>> Handle(GetRoleNamesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetRoleNamesAsync();
        }
    }
}
