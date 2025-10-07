using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.Interfaces;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.Estimate.Commands
{
    public class AddEstimateHandler(IEstimateService service, IMapper mapper)
        : IRequestHandler<AddEstimateCommand, CommandResult>
    {
        private readonly IEstimateService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> Handle(AddEstimateCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<EstimateDto>(request);
            return await _service.AddAsync(dto);
        }
    }
}
