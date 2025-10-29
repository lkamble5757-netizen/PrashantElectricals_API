using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.UserRoleAssignMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.UserRoleAssignMaster;
using PrashantApi.Domain.Entities.UserRoleAssignMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PrashantApi.Application.Feature.UserRoleAssignMaster.Commands
{
    public class UpdateUserRoleAssignMasterHandler : IRequestHandler<UpdateUserRoleAssignMasterCommand, CommandResult>
    {
        private readonly IUserRoleAssignMasterRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserRoleAssignMasterHandler(IUserRoleAssignMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateUserRoleAssignMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<UserRoleAssignMasterModel>(request.UserRoleAssignMaster);
                entity.ModifiedOn = DateTime.Now;

                var result = await _repository.UpdateAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating UserRoleAssignMaster: {ex.Message}");
            }
        }
    }
}
