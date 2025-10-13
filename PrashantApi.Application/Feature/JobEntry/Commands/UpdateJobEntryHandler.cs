using AutoMapper;
using MediatR;
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
    public class UpdateJobEntryHandler : IRequestHandler<UpdateJobEntryCommand, CommandResult>
    {
        private readonly IJobEntryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateJobEntryHandler(IJobEntryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateJobEntryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Map DTO to entity
                var entity = _mapper.Map<JobEntryModel>(request.JobEntry);
                entity.ModifiedOn = DateTime.UtcNow;

                // Call repository update method
                var result = await _repository.UpdateAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating Job Entry: {ex.Message}");
            }
        }
    }
}
