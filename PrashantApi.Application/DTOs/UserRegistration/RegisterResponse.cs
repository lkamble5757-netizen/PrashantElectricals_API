using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.DTOs.UserRegistration
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? Token { get; set; }          // optional: immediate login after register
        public DateTime? ExpiresAt { get; set; }    // optional: token expiry
        public string? Message { get; set; }
    }
}
