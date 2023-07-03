using _4_DM2.Learning.Domain.Entities;

namespace _4_DM2.Learning.Domain.Interfaces.Repositories
{
    public interface IUserImageRepository
    {
        Task Create(UserImage userImage);
        Task Remove(Guid id);
        Task Update(UserImage userImage);
    }
}
