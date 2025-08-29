namespace PrashantApi.Application.DTOs;

public class LoginRequestDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    //public string Id { get; set; } 
    //public string FullName { get; set; } = string.Empty;
    //public string Email { get; set; } = string.Empty;
    //public string PasswordHash { get; set; } = string.Empty; // store hashed passwords
    //public string? RoleIds { get; set; }
}
