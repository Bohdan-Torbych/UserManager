using Microsoft.AspNetCore.Mvc;
using UserManager.Core.Dtos.Requests;
using UserManager.Core.Dtos.Responses;
using UserManager.Core.ServiceContracts;

namespace UserManager.Controllers;

[ApiController]
[Route("{controller}")]
public class AccountController : ControllerBase
{
    private readonly IAccountsService _accountsService;

    public AccountController(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> AddNewUser(UserAddRequest addRequest) =>
        await _accountsService.Register(addRequest);

    [HttpPost("login")]
    public async Task<ActionResult<UserResponse>> LoginUser(LoginRequest loginRequest) =>
        await _accountsService.Login(loginRequest);
}