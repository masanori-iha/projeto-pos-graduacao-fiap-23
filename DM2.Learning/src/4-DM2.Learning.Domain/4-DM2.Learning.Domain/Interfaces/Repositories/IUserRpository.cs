using _4_DM2.Learning.Domain.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DM2.Learning.Domain.Interfaces.Repositories
{
    public interface IUserRpository
    {
        Task<bool> ValidateUser(string login, string password);
    }
}
