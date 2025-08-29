using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.UserRegistration;
using PrashantApi.Application.Feature.RegisterUser;
using PrashantApi.Application.Interfaces.UserRegistration;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    public class UserRegistrationController : Controller
    {
        public readonly IUserRegistrationService _userRegistrationService;
        private readonly IMediator _mediator;

        public UserRegistrationController(IUserRegistrationService userRegistrationService, IMediator mediator)
        {
            _userRegistrationService = userRegistrationService;
            _mediator = mediator;
        }

        // depricated 
        //[HttpPost("register_depricated")]
        //public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        //{
        //    if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        //        return BadRequest(CommandResult.Fail("Username and password are required."));

        //    var response = await _userRegistrationService.RegisterAsync(request);

        //    if (!response.IsSuccess)
        //        // return the whole CommandResult so client always sees { isSuccess, failureReason, output }
        //        return Conflict(response);

        //    return Ok(response);
        //}


        ////using mediateR - optional
        //[HttpPost("registerUsingMediateR")]
        //public async Task<IActionResult> RegisterNew([FromBody] RegisterRequest request)
        //{
        //    if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        //        return BadRequest(CommandResult.Fail("Username and password are required."));

        //    var result = await _mediator.Send(new RegisterUserCommand(request));

        //    if (!result.IsSuccess) return Conflict(result);
        //    return Ok(result);
        //}



    }
}
