using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.ChallanMaster;
using PrashantApi.Application.Feature.ChallanMaster.Commands;
using PrashantApi.Application.Interfaces.ChallanMaster;
using PrashantEle.API.PrashantEle.Application.Common;
using System.Threading.Tasks;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallanMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IChallanMasterRepository _repository;

        public ChallanMasterController(IMediator mediator, IChallanMasterRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<CommandResult>> Create(ChallanMasterDto dto)
        {
            if (dto == null)
                return BadRequest(CommandResult.Fail("Invalid ChallanMaster data."));

            var command = new AddChallanMasterCommand { ChallanMaster = dto };
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.FailureReason);
            }


            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CommandResult>> Update(ChallanMasterDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(CommandResult.Fail("Invalid ChallanMaster data."));

            var command = new UpdateChallanMasterCommand { ChallanMaster = dto };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        
        [HttpGet("GetInvoicesByCustomer/{customerId}")]
        public async Task<IActionResult> GetInvoicesByCustomer(int customerId)
        {
            try
            {
                var result = await _repository.GetInvoicesByCustomerIdAsync(customerId);

                var invoices = result as IEnumerable<dynamic>;

                if (invoices == null || !invoices.Any())
                    return NotFound($"No invoices found for CustomerId {customerId}");

                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetRepairWorkDetailsByJobId/{jobId}")]
        public async Task<IActionResult> GetRepairWorkDetailsByJobId(int jobId)
        {
            try
            {
                var result = await _repository.GetRepairWorkDetailsByJobIdAsync(jobId);

                if (result == null || !((IEnumerable<object>)result).Any())
                    return NotFound($"No repair work details found for JobId {jobId}.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}
