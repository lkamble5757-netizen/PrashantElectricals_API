using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.StockUpdateMaster;
using PrashantApi.Application.Feature.StockUpdateMaster.Commands;
using PrashantApi.Application.Interfaces.StockUpdateMaster;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockUpdateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStockUpdateRepository _repository;

        public StockUpdateController(IMediator mediator, IStockUpdateRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create(StockUpdateMasterDto dto)
        {
            var result = await _mediator.Send(new AddStockUpdateCommand { StockUpdate = dto });
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(StockUpdateMasterDto dto)
        {
            var result = await _mediator.Send(new UpdateStockUpdateCommand { StockUpdate = dto });
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll()
        { 
                var result = await _repository.GetAllAsync();
                return Ok(result);

        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }

}
