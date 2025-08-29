using MediatR;
using PrashantApi.Application.DTOs.UserRegistration;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.RegisterUser
{
    public record RegisterUserCommand(RegisterRequest Request) : IRequest<CommandResult>;

}
