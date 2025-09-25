using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.ReferenceDataMaster;
using PrashantApi.Application.Feature.ReferenceDataMaster.Queries;
using PrashantApi.Application.Interfaces;
using System.Threading;

namespace PrashantApi.Application.Feature.ReferenceDataMaster.Handlers
{
    public class GetUserNamesHandler(IReferenceDataMasterService service)
        : IRequestHandler<GetUserNamesQuery, List<UserDto>>
    {
        private readonly IReferenceDataMasterService _service = service;

        public async Task<List<UserDto>> Handle(GetUserNamesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetUserNamesAsync();
        }
    }
}
