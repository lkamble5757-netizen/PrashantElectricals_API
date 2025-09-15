using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.Feature.CustomerMaster.Commands;
using PrashantApi.Application.Feature.CustomerMaster.Queries;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMasterController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Add")]
        public async Task<ActionResult<int>> Add(AddCustomerMasterCommand command)
        {
            var newId = await _mediator.Send(command);
            return Ok(newId);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<int>> Update(UpdateCustomerMasterCommand command)
        {
            var updatedId = await _mediator.Send(command);
            return Ok(updatedId);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CustomerMasterDto>>> GetAll()
        {
            var customers = await _mediator.Send(new GetAllCustomerMasterQuery());
            return Ok(customers);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<CustomerMasterDto>> GetById(int id)
        {
            var customer = await _mediator.Send(new GetByIdCustomerMasterQuery { Cust_Id = id });
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }
    }
}
