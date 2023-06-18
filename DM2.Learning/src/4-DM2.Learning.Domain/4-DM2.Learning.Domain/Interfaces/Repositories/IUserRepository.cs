using _4_DM2.Learning.Domain.Entities;

namespace _4_DM2.Learning.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<bool> ValidateUser(string login, string password);
    Task<User> GetUserByName(string name);
    Task<User> GetUserById(Guid id);
    Task AddUser(User user);
    Task EditUser(User user);
    Task DeleteUser(Guid id);
}
