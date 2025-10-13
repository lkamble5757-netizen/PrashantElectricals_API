using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.Estimate;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.Estimate;
using PrashantApi.Domain.Entities.Estimate;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.Estimate.Commands
{
    public class UpdateEstimateMasterHandler : IRequestHandler<UpdateEstimateMasterCommand, CommandResult>
    {
        private readonly IEstimateMasterRepository _repository;
        private readonly IMapper _mapper;

        public UpdateEstimateMasterHandler(IEstimateMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateEstimateMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<EstimateMasterModel>(request.EstimateMaster);
 
                var result = await _repository.UpdateAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating Estimate Master: {ex.Message}");
            }
        }
    }

}