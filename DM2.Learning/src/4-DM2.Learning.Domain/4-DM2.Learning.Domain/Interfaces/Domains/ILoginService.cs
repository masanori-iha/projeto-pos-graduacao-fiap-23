using _4_DM2.Learning.Domain.Models;

namespace _4_DM2.Learning.Domain.Interfaces.Domains;

public interface ILoginService
{
    Task<AuthenticateToken> Authenticate(string login, string password);
}
