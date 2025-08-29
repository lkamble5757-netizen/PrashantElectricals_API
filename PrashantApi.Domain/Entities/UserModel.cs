namespace PrashantApi.Domain.Entities;

public class UserModel
{
    public string Id { get; set; } 
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; // store hashed passwords
    public string? RoleIds { get; set; }
    public Boolean? IsActive { get; set; }
    public string? CreatedBy { get; set; }
}
