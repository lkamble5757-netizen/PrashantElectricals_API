using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.MachineMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.MachineMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities.MachineMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.MachineMaster.Commands
{
    public class UpdateMachineMasterHandler : IRequestHandler<UpdateMachineMasterCommand, CommandResult>
    {
        private readonly IMachineMasterRepository _repository;
        private readonly IMapper _mapper;

        public UpdateMachineMasterHandler(IMachineMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateMachineMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<MachineMasterModel>(request.MachineMaster);
                entity.ModifiedOn = DateTime.Now;

                var result = await _repository.UpdateAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating MachineMaster: {ex.Message}");
            }
        }
    }
}


