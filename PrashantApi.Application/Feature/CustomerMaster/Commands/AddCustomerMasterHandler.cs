using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Application.Feature.CustomerMaster.Commands
{
    public class AddCustomerMasterHandler(ICustomerMasterService service, IMapper mapper)
        : IRequestHandler<AddCustomerMasterCommand, int>
    {
        private readonly ICustomerMasterService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(AddCustomerMasterCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<CustomerMasterDto>(request);
            return await _service.AddAsync(dto);
        }
    }
}
