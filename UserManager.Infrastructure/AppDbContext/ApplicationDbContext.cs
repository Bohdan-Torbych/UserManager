using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManager.Core.Entities;

namespace UserManager.Infrastructure.AppDbContext;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    public DbSet<Login> Logins { get; set; }
}