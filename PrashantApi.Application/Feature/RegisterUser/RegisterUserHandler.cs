using MediatR;
using PrashantApi.Application.Interfaces.UserRegistration;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, CommandResult>
    {
        private readonly IUserRegistrationService _service;

        public RegisterUserHandler(IUserRegistrationService service)
        {
            _service = service;
        }

        public Task<CommandResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return _service.RegisterAsync(request.Request);
        }
    }
}
