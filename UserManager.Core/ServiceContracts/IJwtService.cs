using UserManager.Core.Entities;

namespace UserManager.Core.ServiceContracts;

public interface IJwtService
{
    string CreateToken(AppUser user);
}