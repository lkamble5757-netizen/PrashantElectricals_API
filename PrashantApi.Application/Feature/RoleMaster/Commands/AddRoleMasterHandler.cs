using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RoleMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RoleMaster;
using PrashantApi.Domain.Entities.RoleMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.RoleMaster.Commands
{
    public class AddRoleMasterHandler : IRequestHandler<AddRoleMasterCommand, CommandResult>
    {
        private readonly IRoleMasterRepository _repository;
        private readonly IMapper _mapper;

        public AddRoleMasterHandler(IRoleMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(AddRoleMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<RoleMasterModel>(request.RoleMaster);
                return await _repository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding Role Master: {ex.Message}");
            }
        }
    }
}
