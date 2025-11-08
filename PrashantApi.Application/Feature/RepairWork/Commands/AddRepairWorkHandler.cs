using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RepairWork;
using PrashantApi.Application.Feature.Estimate.Commands;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.Estimate;
using PrashantApi.Application.Interfaces.RepairWork;
using PrashantApi.Domain.Entities.Estimate;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantApi.Domain.Entities.RepairWork;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Threading;
using System.Threading.Tasks;
using PrashantApi.Application.Common;

namespace PrashantApi.Application.Feature.RepairWork.Commands
{
    public class AddRepairWorkHandler : IRequestHandler<AddRepairWorkCommand, CommandResult>
    {
       
        private readonly IRepairWorkRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddRepairWorkHandler(IRepairWorkRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddRepairWorkCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<RepairWorkModel>(request.RepairWork);

                var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.Id)?.Value;
                if (int.TryParse(userIdClaim, out var userId))
                    entity.CreatedBy = userId;

                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
                //return CommandResult.Fail($"Error adding Repair Work: {ex.Message}");
            }
        }
    }
}

