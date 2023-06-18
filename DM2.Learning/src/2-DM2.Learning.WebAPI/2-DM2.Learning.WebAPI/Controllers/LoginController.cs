using _3_DM2.Learning.Application.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2_DM2.Learning.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginAppService _loginAppService;

    public LoginController(ILoginAppService loginAppService)
    {
        _loginAppService = loginAppService;
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> Authenticate(string login, string password)
    {
        var authentication = await _loginAppService.Authenticate(login, password);

        if (!authentication.Authenticate)
            return NotFound();

        return Ok(authentication);
    }

   
}
