using Microsoft.AspNetCore.Mvc;
using UserManager.Core.Dtos.Requests;
using UserManager.Core.Dtos.Responses;
using UserManager.Core.ServiceContracts;
using webapi.Filters;

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
    [ModelValidationActionFilter]
    public async Task<ActionResult<UserResponse>> AddNewUser(UserAddRequest addRequest) =>
        await _accountsService.Register(addRequest);

    [HttpPost("login")]
    [ModelValidationActionFilter]
    public async Task<ActionResult<UserResponse>> LoginUser(LoginRequest loginRequest) =>
        await _accountsService.Login(loginRequest);
}