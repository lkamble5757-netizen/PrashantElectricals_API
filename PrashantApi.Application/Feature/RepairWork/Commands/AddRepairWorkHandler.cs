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
    public class AddRepairWorkHandler : IRequestHandler<AddRepairWorkCommand, CommandResult>
    {
        //private readonly IRepairWorkService _service;
        private readonly IRepairWorkRepository _repository;
        private readonly IMapper _mapper;

        public AddRepairWorkHandler(IRepairWorkRepository repository, IMapper mapper)
        {
            //_service = service;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(AddRepairWorkCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<RepairWorkModel>(request.RepairWork);
                //entity.CreatedOn = DateTime.UtcNow;
                var result = await _repository.AddAsync(entity);
                return result;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding Repair Work: {ex.Message}");
            }
        }
    }
}








