using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RoleWiseMenuMaster;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Application.Feature.RoleWiseMenuMaster.Commands
{

    public class AddRoleWiseMenuMasterHandler
    : IRequestHandler<AddRoleWiseMenuMasterCommand>
    {
        private readonly IRoleWiseMenuMasterService _service;
        private readonly IMapper _mapper;

        public AddRoleWiseMenuMasterHandler(IRoleWiseMenuMasterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Handle(AddRoleWiseMenuMasterCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<RoleWiseMenuMasterDto>(request);
            await _service.AddAsync(dto);
        }
    }
}
