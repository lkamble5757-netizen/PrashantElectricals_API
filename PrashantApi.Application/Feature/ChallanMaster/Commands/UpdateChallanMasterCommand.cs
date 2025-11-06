using MediatR;
using PrashantApi.Application.DTOs.ChallanMaster;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Feature.ChallanMaster.Commands
{
    public class UpdateChallanMasterCommand : IRequest<CommandResult>
    {
        public ChallanMasterDto ChallanMaster { get; set; } = default!;
    }
}
