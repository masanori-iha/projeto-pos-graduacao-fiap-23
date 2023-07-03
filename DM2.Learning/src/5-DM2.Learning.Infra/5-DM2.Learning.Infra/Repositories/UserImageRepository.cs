using _4_DM2.Learning.Domain.Entities;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using _5_DM2.Learning.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace _5_DM2.Learning.Infra.Repositories
{
    public class UserImageRepository : BaseRepository, IUserImageRepository
    {
        public UserImageRepository(DM2Context dM2Context) : base(dM2Context) { }

        public async Task Create(UserImage userImage)
        {
            _context.UsersImages.Add(userImage);

            await SaveChanges();
        }

        public async Task Update(UserImage userImage)
        {
            _context.UsersImages.Attach(userImage).State = EntityState.Modified;

            await SaveChanges();
        }

        public async Task Remove(Guid id)
        {
            if (id == Guid.Empty)
                return;

            _context.Remove(new UserImage { Id = id });

            await SaveChanges();

            return;
        }
    }
}
