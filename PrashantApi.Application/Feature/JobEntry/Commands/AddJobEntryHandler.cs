using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.CommonDTO;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.JobEntry;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantApi.Domain.Entities.JobEntry;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.Common;

namespace PrashantApi.Application.Feature.JobEntry.Commands
{
    public class AddJobEntryHandler : IRequestHandler<AddJobEntryCommand, CommandResult>
    {
        private readonly IJobEntryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddJobEntryHandler(IJobEntryRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddJobEntryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<JobEntryModel>(request.JobEntry);

                var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.Id)?.Value;
                if (int.TryParse(userIdClaim, out var userId))
                    entity.CreatedBy = userId;

              //  entity.CreatedOn = DateTime.UtcNow;
            return await _repository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }

            
            
        }
}
