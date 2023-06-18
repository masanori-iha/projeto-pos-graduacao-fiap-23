using _4_DM2.Learning.Domain.Entities;

namespace _4_DM2.Learning.Domain.Interfaces.Domains;

public interface IUserService
{
    Task<User> GetUserByName(string name);
    Task<User> GetUserById(Guid id);
    Task AddUser(User user);
    Task Edituser(User user);
    Task DeleteUser(Guid id);
}
