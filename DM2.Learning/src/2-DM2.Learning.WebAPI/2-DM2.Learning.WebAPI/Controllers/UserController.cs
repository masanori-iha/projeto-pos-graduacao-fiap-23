﻿using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2_DM2.Learning.WebAPI.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserAppService _userAppService;
    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await _userAppService.GetAll();

            if (!users.Any())
                return NotFound();

            return Ok(users);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("[action]/{name}")]
    public async Task<IActionResult> GetUserByName(string name)
    {
        try
        {
            var user = await _userAppService.GetUserByName(name);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        try
        {
            var user = await _userAppService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddUser([FromBody] UserViewModel userViewModel)
    {
        try
        {
            await _userAppService.AddUser(userViewModel);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] UserImageUpdateViewModel userViewModel)
    {
        try
        {
            await _userAppService.EditUser(userViewModel);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("[action]/{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        try
        {
            await _userAppService.DeleteUser(id);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
