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
    public class GetMenuNamesHandler(IReferenceDataMasterService service)
        : IRequestHandler<GetMenuNamesQuery, List<MenuDto>>
    {
        private readonly IReferenceDataMasterService _service = service;

        public async Task<List<MenuDto>> Handle(GetMenuNamesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetMenuNamesAsync();
        }
    }
}
