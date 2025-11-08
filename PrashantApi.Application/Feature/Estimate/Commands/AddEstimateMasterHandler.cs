using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.Estimate;
using PrashantApi.Domain.Entities.Estimate;
using PrashantApi.Infrastructure.Common;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.Common;

namespace PrashantApi.Application.Feature.Estimate.Commands
{
    public class AddEstimateMasterHandler : IRequestHandler<AddEstimateMasterCommand, CommandResult>
    {
        private readonly IEstimateMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExecutionContext _executionContext;

        public AddEstimateMasterHandler(IEstimateMasterRepository repository, IMapper mapper, IExecutionContext executionContext)
        {
            _repository = repository;
            _mapper = mapper;
            _executionContext = executionContext;
        }

        public async Task<CommandResult> Handle(AddEstimateMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<EstimateMasterModel>(request.EstimateMaster);

                var userIdClaim = _executionContext.User?.FindFirst(ClaimTypes.Id)?.Value;
                if (int.TryParse(userIdClaim, out var userId))
                    entity.CreatedBy = userId;

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
