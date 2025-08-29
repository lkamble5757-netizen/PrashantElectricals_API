namespace PrashantApi.Infrastructure.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; // store hashed passwords
    public string? Role { get; set; }
}
