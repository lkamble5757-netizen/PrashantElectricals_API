using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Common
{
    public interface IExecutionContext
    {
        ClaimsPrincipal User { get; }

    }

    public class UserExecutionContext : IExecutionContext
    {
        public ClaimsPrincipal User { get; set; }

        public UserExecutionContext(ClaimsPrincipal user)
        {
            User = user;
        }
    }
}
