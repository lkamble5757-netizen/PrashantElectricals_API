using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantApi.Application.Interfaces;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.JobEntry.Commands
{
    public class UpdateJobEntryHandler(IJobEntryService service, IMapper mapper)
        : IRequestHandler<UpdateJobEntryCommand, CommandResult>
    {
        private readonly IJobEntryService _service = service;
        private readonly IMapper _mapper = mapper;

        public async Task<CommandResult> Handle(UpdateJobEntryCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<JobEntryDto>(request);
            return await _service.UpdateAsync(dto);
        }
    }
}
