using _4_DM2.Learning.Domain.IdentityModels;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _user;
        public UserRepository(UserManager<AppUser> user)
        {
            _user = user;
        }

        public async Task<bool> ValidateUser(string login, string password)
        {
            var user = await _user.FindByNameAsync(login);

            var result = _user != null && await _user.CheckPasswordAsync(user, password);
            return result;
        }
    }
}
