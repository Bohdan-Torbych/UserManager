using Microsoft.AspNetCore.Mvc;
using UserManager.Core.Dtos.Responses;
using UserManager.Core.ServiceContracts;

namespace UserManager.Controllers;

[ApiController]
[Route("{controller}")]
public class LoginsController :ControllerBase
{
    private readonly ILoginsService _loginsService;

    public LoginsController(ILoginsService loginsService)
    {
        _loginsService = loginsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<LoginResponse>>> GetAllLogins() =>
        await _loginsService.GetAllLogins();
}