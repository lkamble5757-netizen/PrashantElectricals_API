using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using PrashantApi.Application.DTOs.MachineMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.MachineMaster;
using PrashantApi.Domain.Entities.ItemMaster;
using PrashantApi.Domain.Entities.MachineMaster;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PrashantApi.Application.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.MachineMaster.Commands
{
    public class AddMachineMasterHandler : IRequestHandler<AddMachineMasterCommand, CommandResult>
    {
        private readonly IMachineMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddMachineMasterHandler(IMachineMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddMachineMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<MachineMasterModel>(request.MachineMaster);

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


