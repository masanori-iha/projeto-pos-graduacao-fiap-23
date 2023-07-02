using _3_DM2.Learning.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using _6_DM2.Learning.Infra.WeAPI.Models;
using System.Diagnostics.CodeAnalysis;

namespace _1_DM2.Learning.Presentation.Areas.User.Controllers;

[Area("User")]
[Route("[controller]/[action]")]
public class UserRegisterController : Controller
{
    
    private readonly UserControllerWebApi _user;

    public UserRegisterController(UserControllerWebApi user)
    {
        _user = user;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> GetAll()
    {
        var users = await _user.GetAll();

        if(!users.Any())
            return PartialView("_UserList", new List<UserViewModel>());

        return PartialView("_UserList", users);
    }

    public async Task<IActionResult> GetUserDetails(Guid id)
    {
        var user = await _user.GetUserById(id);

        return PartialView("_UserDetails", user);
    }

    public async Task<IActionResult> Create()
    {
        return PartialView("_UserCreate", new UserViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBodyAttribute] UserViewModel user)
    {
        await _user.Create(user);

        var users = await _user.GetAll();

        return PartialView("_UserList", users);
    }

    public async Task<IActionResult> Update(Guid id)
    {
        var user = await _user.GetUserById(id);

        return PartialView("_UserEdit", user);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserViewModel userUpdate)
    {
        await _user.Update(userUpdate);

        var user = await _user.GetUserById(userUpdate.Id);

        return PartialView("_UserEdit", user);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _user.Delete(id);

        var users = await _user.GetAll();

        return PartialView("_UserList", users);
    }


    [HttpPost]
    public async Task<IActionResult> RegisterNewUser([FromBody] UserViewModel NewUser)
    {
        if (NewUser == null) { 
            return View("Error");
        }

        return View("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UploadUserImage(IEnumerable<IFormFile> files)
    {
        return View("Index");
    }

}
