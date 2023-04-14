using AutoMapper;
using UserManager.Core.Dtos.Requests;
using UserManager.Core.Dtos.Responses;
using UserManager.Core.Entities;
using UserManager.Core.Enumerations;
using UserManager.Core.RepositotyContracts;
using UserManager.Core.ServiceContracts;

namespace UserManager.Core.Services;

public class AccountsService : IAccountsService
{
    private readonly IUsersRepository _usersRepository;
    private readonly ILoginsService _loginsService;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public AccountsService(IUsersRepository usersRepository, IMapper mapper, ILoginsService loginsService, IJwtService jwtService)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
        _loginsService = loginsService;
        _jwtService = jwtService;
    }

    public async Task<UserResponse> Register(UserAddRequest userAddRequest)
    {
        var appUser = await _usersRepository.SaveUser(_mapper.Map<AppUser>(userAddRequest), userAddRequest.Password!);

        if (appUser == null)
            throw new ArgumentException("Registration was unsuccessful");
        appUser.Token = _jwtService.CreateToken(appUser);

        return _mapper.Map<UserResponse>(appUser);
    }

    public async Task<UserResponse> Login(LoginRequest loginRequest)
    {
        var user = await _usersRepository.Login(loginRequest.Email!, loginRequest.Password!);
        var loginInfo = new LoginAddRequest()
        {
            Email = loginRequest.Email,
            DateStamp = DateTime.UtcNow
        };

        if (user == null)
        {
            await AddLoginInfo(loginInfo, Status.Failed);
            throw new ArgumentException("Invalid username or password");
        }
        await AddLoginInfo(loginInfo, Status.Succeeded);
        user.Token = _jwtService.CreateToken(user);
        return _mapper.Map<UserResponse>(user);
    }

    private async Task AddLoginInfo(LoginAddRequest loginInfo, Status status)
    {
        loginInfo.Status = status;
        await _loginsService.AddNewLogin(loginInfo);
    }
}