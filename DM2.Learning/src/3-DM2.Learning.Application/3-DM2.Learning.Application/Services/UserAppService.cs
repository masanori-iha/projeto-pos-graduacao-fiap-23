using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.ViewModels;
using _4_DM2.Learning.Domain.Entities;
using _4_DM2.Learning.Domain.Interfaces.Domains;
using _5._1_DM2.Learning.Infra.Azure.Storage.Dtos;
using AutoMapper;

namespace _3_DM2.Learning.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly FileAzureStorageService _fileAzureStorageService;

    public UserAppService(IMapper mapper, 
                          IUserService userService, 
                          FileAzureStorageService fileAzureStorageService)
    {
        _mapper = mapper;
        _userService = userService;
        _fileAzureStorageService = fileAzureStorageService;
    }

    public async Task<IEnumerable<UserViewModel>> GetAll()
    {
        var users = await _userService.GetAll();

        return _mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    public async Task<UserViewModel> GetUserByName(string name)
    {
        var user = await _userService.GetUserByName(name);

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<UserViewModel> GetUserById(Guid id)
    {
        var user = await _userService.GetUserById(id);
        var userViwModel = _mapper.Map<UserViewModel>(user);

        if (!string.IsNullOrEmpty(userViwModel?.UserImage?.Name))
            userViwModel.UserImage.Url = _fileAzureStorageService.ObterUrlBlob(userViwModel.UserImage.Name);
        else
            userViwModel.UserImage = new UserImageViewModel() { Url = string.Empty };
            
        return userViwModel;
    }

    public async Task AddUser(UserViewModel userViewModel)
    {
        var user = _mapper.Map<User>(userViewModel);

        await _userService.AddUser(user);
    }

    public async Task EditUser(UserImageUpdateViewModel userViewModel)
    {
        var user = _mapper.Map<User>(userViewModel);

        await _userService.Edituser(user);
    }

    public async Task DeleteUser(Guid id)
    {
        await _userService.DeleteUser(id);
    }
}
