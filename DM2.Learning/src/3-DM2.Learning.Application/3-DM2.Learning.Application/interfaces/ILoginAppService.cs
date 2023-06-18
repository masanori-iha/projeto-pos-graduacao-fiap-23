using _3_DM2.Learning.Application.ViewModels;

namespace _3_DM2.Learning.Application.interfaces;

public interface ILoginAppService
{
    Task<AuthenticateTokenViewModel> Authenticate(string login,  string password);
}
