using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManager.Core.Entities;
using UserManager.Infrastructure.AppDbContext;

namespace UserManager.StartupExtension;

public static class DbConfigureExtension
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddUserStore<UserStore<AppUser, AppRole, ApplicationDbContext, Guid>>()
            .AddRoleStore<RoleStore<AppRole, ApplicationDbContext, Guid>>();
    }
}