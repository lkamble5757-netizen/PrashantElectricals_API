using AutoMapper;
using MediatR;
using PrashantApi.Application.Common;
using PrashantApi.Application.DTOs.RoleMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.RoleMaster;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantApi.Domain.Entities.RoleMaster;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.RoleMaster.Commands
{
    public class AddRoleMasterHandler : IRequestHandler<AddRoleMasterCommand, CommandResult>
    {
        private readonly IRoleMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddRoleMasterHandler(IRoleMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddRoleMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<RoleMasterModel>(request.RoleMaster);

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
