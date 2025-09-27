// Api/Controllers/BranchMasterController.cs
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs;
using PrashantApi.Application.DTOs.BranchMaster;
using PrashantApi.Application.Feature.BranchMaster.Commands;
using PrashantApi.Application.Feature.BranchMaster.Queries;

namespace PrashantApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BranchMasterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BranchMasterDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetBranchByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }
        //test
        [HttpPost]
        public async Task<ActionResult<int>> Add(AddBranchMasterCommand command)
        {
            var newId = await _mediator.Send(command);
            return Ok(newId);
        }
    }
}
