using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.Feature.CustomerMaster.Queries;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Application.Feature.CustomerMaster.Handlers
{
    public class GetByIdCustomerMasterHandler(ICustomerMasterService service, IMapper mapper)
        : IRequestHandler<GetByIdCustomerMasterQuery, CustomerMasterDto>
    {
        private readonly ICustomerMasterService _service = service;
        private readonly IMapper mapper = mapper;

        public async Task<CustomerMasterDto> Handle(GetByIdCustomerMasterQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Cust_Id);
        }
    }
}
