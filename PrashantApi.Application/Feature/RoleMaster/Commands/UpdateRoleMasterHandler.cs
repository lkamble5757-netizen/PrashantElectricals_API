using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RoleMaster;
using PrashantApi.Application.Interfaces;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.RoleMaster;
using PrashantApi.Application.Interfaces.RoleMaster;

namespace PrashantApi.Application.Feature.RoleMaster.Commands
{
    public class UpdateRoleMasterHandler : IRequestHandler<UpdateRoleMasterCommand, CommandResult>
    {
        private readonly IRoleMasterRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRoleMasterHandler(IRoleMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateRoleMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<RoleMasterModel>(request.RoleMaster);
                return await _repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating Role Master: {ex.Message}");
            }
        }
    }
}
