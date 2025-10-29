using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RoleWiseMenuMaster;
using PrashantApi.Domain.Entities.RoleWiseMenuMaster;
using PrashantEle.API.PrashantEle.Application.Common;


namespace PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands
{
    public class AddRoleWiseMenuMasterHandler : IRequestHandler<AddRoleWiseMenuMasterCommand, CommandResult>
    {
        private readonly IRoleWiseMenuMasterRepository _repository;
        private readonly IMapper _mapper;

        public AddRoleWiseMenuMasterHandler(IRoleWiseMenuMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(AddRoleWiseMenuMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<RoleWiseMenuMasterModel>(request.RoleWiseMenuMaster);
                entity.CreatedOn = DateTime.Now;

                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding RoleWiseMenuMaster: {ex.Message}");
            }
        }
    }
}
