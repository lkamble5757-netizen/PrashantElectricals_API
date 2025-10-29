using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.CommonDTO;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.JobEntry;
using PrashantApi.Domain.Entities.JobEntry;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.JobEntry.Commands
{
    public class AddJobEntryHandler : IRequestHandler<AddJobEntryCommand, CommandResult>
    {
        private readonly IJobEntryRepository _repository;
        private readonly IMapper _mapper;

        public AddJobEntryHandler(IJobEntryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(AddJobEntryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<JobEntryModel>(request.JobEntry);
            entity.CreatedOn = DateTime.UtcNow;
            return await _repository.AddAsync(entity);
        }
    }
}
