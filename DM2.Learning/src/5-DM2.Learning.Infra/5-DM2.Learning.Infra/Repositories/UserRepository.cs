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
        public async Task<bool> ValidateUser(string login, string password)
        {
            return true;
        }
    }
}
