using UserManager.Core.Dtos.Responses;

namespace UserManager.Core.ServiceContracts;

public interface IUsersService
{
    Task<List<UserResponse>> GetAllUsers();
}