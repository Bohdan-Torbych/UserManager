using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManager.Core.Entities;
using UserManager.Core.RepositotyContracts;

namespace UserManager.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public UsersRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<AppUser?> SaveUser(AppUser appUser, string password)
    {
        if (await _userManager.FindByEmailAsync(appUser.Email!) != null)
            throw new ArgumentException("Email is already exist");

        appUser.Id = Guid.NewGuid();
        var result = await _userManager.CreateAsync(appUser, password);

        return result.Succeeded ? appUser : null;
    }

    public async Task<AppUser?> Login(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

        return result.Succeeded 
            ? await _userManager.Users.FirstAsync(u => u.Email == username)
            : null;
    }

    public async Task<List<AppUser>> FindAllUsers() =>
        await _userManager.Users.ToListAsync();
}