using _3_DM2.Learning.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using _6_DM2.Learning.Infra.WeAPI.Models;
using System.Diagnostics.CodeAnalysis;
using _5._1_DM2.Learning.Infra.Azure.Storage.Dtos;

namespace _1_DM2.Learning.Presentation.Areas.User.Controllers;

[Area("User")]
[Route("[controller]/[action]")]
public class UserRegisterController : Controller
{
    
    private readonly UserControllerWebApi _user;
    private readonly UserImageControllerWebApi _userImage;
    private readonly FileAzureStorageService _fileAzureStorageService;

    public UserRegisterController(UserControllerWebApi user, 
                                  UserImageControllerWebApi userImage, 
                                  FileAzureStorageService fileAzureStorageService)
    {
        _user = user;
        _userImage = userImage;
        _fileAzureStorageService = fileAzureStorageService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _user.GetAll();

        if(!users.Any())
            return PartialView("_UserList", new List<UserViewModel>());

        return PartialView("_UserList", users);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserDetails(Guid id)
    {
        var user = await _user.GetUserById(id);

        return PartialView("_UserDetails", user);
    }


    [HttpGet]
    public IActionResult Create()
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

    
    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        var user = await _user.GetUserById(id);

        return PartialView("_UserEdit", user);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBodyAttribute] UserImageUpdateViewModel userUpdate)
    {
        await _user.Update(userUpdate);

        var users = await _user.GetAll();

        return PartialView("_UserList", users);
    }

    
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _user.Delete(id);

        var users = await _user.GetAll();
        return PartialView("_UserList", users);
    }

    [HttpPost]
    public async Task<IActionResult> UploadUserImage(Guid userImageId, IEnumerable<IFormFile> files, Guid userId)
    {

        var userImageViewModel = new UserImageViewModel();
        userImageViewModel.Name = files.ToList()[0].FileName;
        userImageViewModel.Id = userImageId;
        userImageViewModel.UserId = userId;

        await _userImage.Update(userImageViewModel);

        await _fileAzureStorageService.UploadAsync(files.ToList()[0]);

        return Json(new { success = true });
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveUserImage(Guid userId, Guid imageId, string imageName)
    {
        await _userImage.Remove(imageId);

        await _fileAzureStorageService.Excluir(imageName);

        var user = await _user.GetUserById(userId);
        return PartialView("_UserDetails", user);
    }
}
