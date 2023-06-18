using _3_DM2.Learning.Application.ViewModels;

namespace _3_DM2.Learning.Application.interfaces;

public interface IUserAppService
{
    Task<UserViewModel> GetUserByName(string name);
    Task<UserViewModel> GetUserById(Guid id);
    Task AddUser(UserViewModel userViewModel);
    Task EditUser(UserViewModel userViewModel);
    Task DeleteUser(Guid id);

}
