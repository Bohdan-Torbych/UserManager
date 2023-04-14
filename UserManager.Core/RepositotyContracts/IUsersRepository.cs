using UserManager.Core.Entities;

namespace UserManager.Core.RepositotyContracts;

public interface IUsersRepository
{
    Task<AppUser?> SaveUser(AppUser appUser, string password);

    Task<AppUser?> Login(string username, string password);

    Task<List<AppUser>> FindAllUsers();
}