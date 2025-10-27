using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RoleWiseMenuMaster;
using PrashantApi.Domain.Entities.RoleWiseMenuMaster;
using PrashantEle.API.PrashantEle.Application.Common;


namespace PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands
{
    public class UpdateRoleWiseMenuMasterHandler : IRequestHandler<UpdateRoleWiseMenuMasterCommand, CommandResult>
    {
        private readonly IRoleWiseMenuMasterRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRoleWiseMenuMasterHandler(IRoleWiseMenuMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateRoleWiseMenuMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<RoleWiseMenuMasterModel>(request.RoleWiseMenuMaster);
                entity.ModifiedOn = DateTime.Now;

                var result = await _repository.UpdateAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating RoleWiseMenuMaster: {ex.Message}");
            }
        }
    }
}
