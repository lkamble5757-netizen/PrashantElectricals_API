//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using PrashantApi.Application.DTOs.LedgerMaster;
//using PrashantApi.Application.Feature.LedgerMaster.Commands;
//using PrashantApi.Application.Interfaces.LedgerMaster;
//using PrashantEle.API.PrashantEle.Application.Common;

//namespace PrashantApi.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LedgerMasterController(IMediator mediator, ILedgerMasterRepository repository) : ControllerBase
//    {
//        private readonly IMediator _mediator = mediator;
//        private readonly ILedgerMasterRepository _repository = repository;

//        [HttpPost("Add")]
//        public async Task<ActionResult<CommandResult>> Create(LedgerMasterDto dto)
//        {
//            if (dto == null)
//                return BadRequest(CommandResult.Fail("Invalid Ledger data."));

//            var command = new AddLedgerMasterCommand { Ledger = dto };
//            var result = await _mediator.Send(command);

//            if (!result.IsSuccess)
//            {
//                return BadRequest(result.FailureReason);
//            }

//            return result.IsSuccess ? Ok(result) : BadRequest(result);
//        }

//        [HttpPut("Update")]
//        public async Task<ActionResult<CommandResult>> Update(LedgerMasterDto dto)
//        {
//            if (dto == null || dto.Id <= 0)
//                return BadRequest(CommandResult.Fail("Invalid Ledger data."));

//            var command = new UpdateLedgerMasterCommand { Ledger = dto };
//            var result = await _mediator.Send(command);
//            return result.IsSuccess ? Ok(result) : BadRequest(result);
//        }

//        [HttpGet("GetAll")]
//        public async Task<ActionResult<dynamic>> GetAll()
//        {
//            var result = await _repository.GetAllAsync();
//            return Ok(result);
//        }

//        [HttpGet("GetBy/{id}")]
//        public async Task<ActionResult<dynamic>> GetById(int id)
//        {
//            var result = await _repository.GetByIdAsync(id);
//            if (result == null || ((ICollection<dynamic>)result).Count == 0)
//                return NotFound($"No Ledger found with Id {id}");

//            return Ok(result);
//        }
//    }
//}

