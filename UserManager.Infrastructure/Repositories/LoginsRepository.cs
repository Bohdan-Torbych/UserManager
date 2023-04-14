using Microsoft.EntityFrameworkCore;
using UserManager.Core.Entities;
using UserManager.Core.RepositotyContracts;
using UserManager.Infrastructure.AppDbContext;

namespace UserManager.Infrastructure.Repositories;

public class LoginsRepository : ILoginsRepository
{
    private readonly ApplicationDbContext _db;

    public LoginsRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Login?> SaveLogin(Login login)
    { 
        login.Id = Guid.NewGuid();
        await _db.Logins.AddAsync(login);

        return await _db.SaveChangesAsync() > 0 ? login : null;
    }

    public async Task<List<Login>> FindAllLogins() =>
        await _db.Logins.ToListAsync();
}