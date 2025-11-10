using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RoleWiseMenuMaster;
using PrashantApi.Domain.Entities.RoleWiseMenuMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantApi.Application.Common;
using PrashantApi.Infrastructure.Common;

namespace PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands
{
    public class AddRoleWiseMenuMasterHandler : IRequestHandler<AddRoleWiseMenuMasterCommand, CommandResult>
    {
        private readonly IRoleWiseMenuMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddRoleWiseMenuMasterHandler( IRoleWiseMenuMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddRoleWiseMenuMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<RoleWiseMenuMasterModel>(request.RoleWiseMenuMaster);

                var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.Id)?.Value;
                if (int.TryParse(userIdClaim, out var userId))
                    entity.CreatedBy = userId;

                entity.CreatedOn = DateTime.Now;

                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }
    }
}