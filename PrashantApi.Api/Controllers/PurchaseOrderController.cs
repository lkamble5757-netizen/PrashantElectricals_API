using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.PurchaseOrder;
using PrashantApi.Application.Feature.PurchaseOrder.Commands;
using PrashantApi.Application.Interfaces.PurchaseOrder;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPurchaseOrderRepository _repository;

        public PurchaseOrderController(IMediator mediator, IPurchaseOrderRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create(PurchaseOrderMasterDto dto)
        {
            var result = await _mediator.Send(new AddPurchaseOrderCommand { PurchaseOrder = dto });
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PurchaseOrderMasterDto dto)
        {
            var result = await _mediator.Send(new UpdatePurchaseOrderCommand { PurchaseOrder = dto });
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
