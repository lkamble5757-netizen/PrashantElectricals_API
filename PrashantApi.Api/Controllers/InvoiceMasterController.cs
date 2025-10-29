using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.InvoiceMaster;
using PrashantApi.Application.DTOs.RepairWork;
using PrashantApi.Application.Feature.InvoiceMaster.Commands;
using PrashantApi.Application.Feature.RepairWork.Commands;
using PrashantApi.Application.Interfaces.InvoiceMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Threading.Tasks;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IInvoiceMasterRepository _repository;

        public InvoiceMasterController(IMediator mediator, IInvoiceMasterRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }


        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(InvoiceMasterDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid InvoiceMaster data."));

            var command = new AddInvoiceMasterCommand { InvoiceMaster = dto };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }




        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(InvoiceMasterDto dto)
        {
            if (dto == null || dto.Id <= 0)
            {
                return BadRequest(CommandResult.Fail("Invalid InvoiceMaster data."));
            }

            var command = new UpdateInvoiceMasterCommand { InvoiceMaster = dto };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<InvoiceMasterDto>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<InvoiceMasterDto>> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }



        [HttpGet("GetCustomerWiseRepairData/{customerId}")]
        public async Task<IActionResult> GetCustomerWiseRepairData(int customerId)
        {
            var result = await _repository.GetCustomerWiseRepairDataAsync(customerId);
            return Ok(result);
        }


    }
}
