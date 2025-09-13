using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Feature.BranchMaster.Commands;
using PrashantApi.Application.Feature.ItemMaster.Commands;
using PrashantApi.Application.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using PrashantApi.Application.Feature.ItemMaster.Queries;

namespace PrashantApi.Api.Controllers
{
    [ApiController]
    [Route("api/itemMaster")]
    //[Authorize]
    public class ItemMasterController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<int>> Add(AddItemMasterCommand command)
        {

            var newId = await _mediator.Send(command);
            return Ok(newId);
        }


        [HttpPut]
        public async Task<ActionResult<int>> Update(UpdateItemMasterCommand command)
        {
            var updatedId = await _mediator.Send(command);
            return Ok(updatedId);
        }


        [HttpGet]
        public async Task<ActionResult<List<ItemMasterDto>>> GetAll()
        {
            var items = await _mediator.Send(new GetAllItemMasterQuery());
            return Ok(items);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ItemMasterDto>> GetById(int id)
        {
            var item = await _mediator.Send(new GetByIdItemMasterQuery { Id = id });
            if (item == null)
                return NotFound();

            return Ok(item);
        }

    }
}
