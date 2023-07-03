using _3_DM2.Learning.Application.ViewModels;

namespace _3_DM2.Learning.Application.Interfaces;

public interface IUserImageAppService
{
    Task Remove(Guid id);
    Task Update(UserImageViewModel userImageViewModel);
}
