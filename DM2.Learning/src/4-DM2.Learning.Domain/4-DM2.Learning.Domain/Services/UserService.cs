using _4_DM2.Learning.Domain.Entities;
using _4_DM2.Learning.Domain.Interfaces.Domains;
using _4_DM2.Learning.Domain.Interfaces.Repositories;

namespace _4_DM2.Learning.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRpository)
    {
        _userRepository = userRpository;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetUserByName(string name)
    {
        return await _userRepository.GetUserByName(name);
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task AddUser(User user)
    {
        await _userRepository.AddUser(user);
    }

    public async Task Edituser(User user)
    {
        await _userRepository.EditUser(user);
    }
    public async Task DeleteUser(Guid id)
    {
        await _userRepository.DeleteUser(id);
    }
}
