using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.MachineMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.MachineMaster;
using PrashantApi.Domain.Entities.MachineMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.MachineMaster.Commands
{
    public class AddMachineMasterHandler : IRequestHandler<AddMachineMasterCommand, CommandResult>
    {
        private readonly IMachineMasterRepository _repository;
        private readonly IMapper _mapper;

        public AddMachineMasterHandler(IMachineMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(AddMachineMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<MachineMasterModel>(request.MachineMaster);
                entity.CreatedOn = DateTime.Now;

                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding MachineMaster: {ex.Message}");
            }
        }
    }
}


