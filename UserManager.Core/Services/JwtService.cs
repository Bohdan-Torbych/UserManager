using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using UserManager.Core.Entities;
using UserManager.Core.ServiceContracts;
using System.Text;

namespace UserManager.Core.Services;

public class JwtService : IJwtService
{
    private readonly SymmetricSecurityKey _key;

    public JwtService(IConfiguration configuration)
    {
        var configSection = configuration.GetSection("Jwt");
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configSection.GetSection("Key").Value!));
    }

    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.NameId, user.Email!)
        };
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}