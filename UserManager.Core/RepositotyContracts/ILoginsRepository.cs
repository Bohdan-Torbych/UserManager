using UserManager.Core.Entities;

namespace UserManager.Core.RepositotyContracts;
public interface ILoginsRepository
{
    Task<Login?> SaveLogin(Login login);

    Task<List<Login>> FindAllLogins();

}
