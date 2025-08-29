using Microsoft.EntityFrameworkCore;
using PrashantApi.Domain.Entities;
using PrashantApi.Infrastructure.Entities;

namespace PrashantApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    //public DbSet<User> Users { get; set; } = null!;
}
