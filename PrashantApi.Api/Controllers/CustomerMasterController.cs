using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.CustomerMaster;
using PrashantApi.Application.Feature.CustomerMaster.Commands;
using PrashantApi.Application.Interfaces;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMasterController(IMediator mediator, ICustomerMasterService service) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ICustomerMasterService _service = service;


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
            var customers = await _service.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<CustomerMasterDto>> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }
    }
}
