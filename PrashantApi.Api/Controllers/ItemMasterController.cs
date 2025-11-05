using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Feature.BranchMaster.Commands;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantApi.Application.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using PrashantApi.Application.Interfaces.ItemMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMasterController(IMediator mediator, IItemMasterRepository repository) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IItemMasterRepository _repository = repository;

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(ItemMasterDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid ItemMaster data."));

            var command = new AddItemMasterCommand { ItemMaster = dto };    
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.FailureReason);
            }

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(ItemMasterDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(CommandResult.Fail("Invalid ItemMaster data."));

            var command = new UpdateItemMasterCommand { ItemMaster = dto };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }


        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null || ((ICollection<dynamic>)item).Count == 0)
                return NotFound($"No ItemMaster found with Id {id}");

            return Ok(item);
        }
    }
}