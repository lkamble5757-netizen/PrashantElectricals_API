using AutoMapper;
using MediatR;
using PrashantApi.Application.Common;
using PrashantApi.Application.Interfaces.ChallanMaster;
using PrashantApi.Domain.Entities.ChallanMaster;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.ChallanMaster.Commands
{
    public class AddChallanMasterHandler : IRequestHandler<AddChallanMasterCommand, CommandResult>
    {
        private readonly IChallanMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddChallanMasterHandler(IChallanMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddChallanMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<ChallanMasterModel>(request.ChallanMaster);

                var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.Id)?.Value;
                if (int.TryParse(userIdClaim, out var userId))
                    entity.CreatedBy = userId;

                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding ChallanMaster: {ex.Message}");
            }
        }
    }
}
