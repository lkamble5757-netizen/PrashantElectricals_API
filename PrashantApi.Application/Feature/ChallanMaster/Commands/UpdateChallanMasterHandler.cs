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
    public class UpdateChallanMasterHandler : IRequestHandler<UpdateChallanMasterCommand, CommandResult>
    {
        private readonly IChallanMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;


        public UpdateChallanMasterHandler(IChallanMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(UpdateChallanMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<ChallanMasterModel>(request.ChallanMaster);


                var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.Id)?.Value;
                if (int.TryParse(userIdClaim, out var userId))
                    entity.ModifiedBy = userId;

                var result = await _repository.UpdateAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating ChallanMaster: {ex.Message}");
            }
        }
    }
}
