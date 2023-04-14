using UserManager.Core.Dtos.Requests;
using UserManager.Core.Dtos.Responses;

namespace UserManager.Core.ServiceContracts;

public interface ILoginsService
{
    Task<LoginResponse> AddNewLogin(LoginAddRequest loginAddRequest);

    Task<List<LoginResponse>> GetAllLogins();
}