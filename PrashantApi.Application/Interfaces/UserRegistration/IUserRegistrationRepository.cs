using PrashantApi.Application.DTOs.UserRegistration;
using PrashantApi.Domain.Entities;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Interfaces.UserRegistration
{
    public interface IUserRegistrationRepository
    { 
        Task<CommandResult> RegisterAsync(RegisterRequest request);
    }
}
