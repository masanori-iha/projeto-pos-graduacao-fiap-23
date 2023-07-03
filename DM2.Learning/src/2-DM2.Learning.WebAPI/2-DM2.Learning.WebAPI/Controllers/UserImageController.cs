using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.Interfaces;
using _3_DM2.Learning.Application.ViewModels;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2_DM2.Learning.WebAPI.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserImageController : ControllerBase
{
    private readonly IUserImageAppService _appService;

    public UserImageController(IUserImageAppService appService)
    {
        _appService = appService;
    }

    
    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] UserImageViewModel userImageViewModel)
    {
        try
        {
            await _appService.Update(userImageViewModel);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("[action]/{id:guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        try
        {
            await _appService.Remove(id);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
