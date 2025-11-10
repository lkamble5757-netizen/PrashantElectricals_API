using AutoMapper;
using MediatR;
using PrashantApi.Application.Common;
using PrashantApi.Application.DTOs.UserRoleAssignMaster;
using PrashantApi.Application.Interfaces.UserRoleAssignMaster;
using PrashantApi.Domain.Entities.UserRoleAssignMaster;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.UserRoleAssignMaster.Commands
{
    public class AddUserRoleAssignMasterHandler : IRequestHandler<AddUserRoleAssignMasterCommand, CommandResult>
    {
        private readonly IUserRoleAssignMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddUserRoleAssignMasterHandler( IUserRoleAssignMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddUserRoleAssignMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<UserRoleAssignMasterModel>(request.UserRoleAssignMaster);

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