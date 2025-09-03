using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.UserRegistration;
using PrashantApi.Application.Feature.RegisterUser;
using PrashantApi.Application.Interfaces.UserRegistration;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Api.Controllers
{
    [Authorize] 
    public class UserRegistrationController : Controller
    {
        public readonly IUserRegistrationService _userRegistrationService;
        private readonly IMediator _mediator;

        public UserRegistrationController(IUserRegistrationService userRegistrationService, IMediator mediator)
        {
            _userRegistrationService = userRegistrationService;
            _mediator = mediator;
        }
    }
}
