using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantApi.Application.Feature.JobEntry.Commands;
using PrashantApi.Application.Interfaces;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantApi.Domain.Entities.JobEntry;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobEntryController(IMediator mediator, IJobEntryService service) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IJobEntryService _service = service;

        //[HttpPost("Add")]
        //public async Task<ActionResult<CommandResult>> Add(AddJobEntryCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(JobEntryDto dto)
        {
            if (dto is null)
                return BadRequest(CommandResult.Fail("Invalid Job Entry data."));

            var command = new AddJobEntryCommand { JobEntry = dto };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(UpdateJobEntryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<JobEntryDto>>> GetAll()
        {
            var entries = await _service.GetAllAsync();
            return Ok(entries);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<IEnumerable<JobEntryDto>>> GetById(int id)
        {
            var entries = await _service.GetByIdAsync(id);
            if (entries == null || !entries.Any())
                return NotFound();

            return Ok(entries);
        }
    }
}
