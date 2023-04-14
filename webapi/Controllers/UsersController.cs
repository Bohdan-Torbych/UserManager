using Microsoft.AspNetCore.Mvc;
using UserManager.Core.Dtos.Responses;
using UserManager.Core.ServiceContracts;

namespace UserManager.Controllers;

[ApiController]
[Route("{controller}")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetAllUsers() =>
    await _usersService.GetAllUsers();
}