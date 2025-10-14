using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.RepairWork;
using PrashantApi.Application.Feature.Estimate.Commands;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.Estimate;
using PrashantApi.Application.Interfaces.RepairWork;
using PrashantApi.Domain.Entities.Estimate;
using PrashantApi.Domain.Entities.RepairWork;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.RepairWork.Commands
{
    public class UpdateRepairWorkHandler : IRequestHandler<UpdateRepairWorkCommand, CommandResult>
    {
        //private readonly IRepairWorkService _service;
        private readonly IRepairWorkRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRepairWorkHandler(IRepairWorkRepository repository, IMapper mapper)
        {
            //_service = service;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateRepairWorkCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<RepairWorkModel>(request.RepairWork);

                var result = await _repository.UpdateAsync(entity);
                return result;

            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error updating Repair Work: {ex.Message}");
            }

        }
    }
}
