using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UserManager.Core.RepositotyContracts;
using UserManager.Core.ServiceContracts;
using UserManager.Core.Services;
using UserManager.Infrastructure.Repositories;

namespace UserManager.StartupExtension;

public static class ServicesExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IAccountsService, AccountsService>();
        services.AddScoped<ILoginsService, LoginsService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ILoginsRepository, LoginsRepository>();
        // Add AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // JWT
        var jwtConfig = configuration.GetSection("Jwt");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.GetSection("Key").Value!)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }
}