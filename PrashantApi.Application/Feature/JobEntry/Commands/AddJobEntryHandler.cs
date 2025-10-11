using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.JobEntry;
using PrashantApi.Domain.Entities.JobEntry;
using PrashantEle.API.PrashantEle.Application.Common;

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
            try
            {
                var entity = _mapper.Map<JobEntryModel>(request.JobEntry);
                entity.CreatedOn = DateTime.UtcNow;

                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding Job Entry: {ex.Message}");
            }
        }
    }
}
