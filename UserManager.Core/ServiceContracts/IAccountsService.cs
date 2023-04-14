using UserManager.Core.Dtos.Requests;
using UserManager.Core.Dtos.Responses;

namespace UserManager.Core.ServiceContracts;

public interface IAccountsService
{
    Task<UserResponse> Register(UserAddRequest userAddRequest);

    Task<UserResponse> Login(LoginRequest loginRequest);
}