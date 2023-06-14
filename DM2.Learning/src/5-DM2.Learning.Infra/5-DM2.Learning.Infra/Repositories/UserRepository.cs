using _4_DM2.Learning.Domain.Entities;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using _5_DM2.Learning.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _5_DM2.Learning.Infra.Repositories
{
    public class UserRepository : IUserRpository
    {
        private readonly DM2Context _context;
        public UserRepository(DM2Context dM2Context)
        {
            _context = dM2Context;
        }
        public async Task<bool> ValidateUser(string login, string password)
        {
            await Task.Delay(1);

            return true;
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _context.Users.Include(user => user.UserImage).FirstOrDefaultAsync(user => user.Name.Equals(name));
        }
    }
}
