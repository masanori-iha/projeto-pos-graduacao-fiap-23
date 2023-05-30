using _4_DM2.Learning.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DM2.Learning.Domain.Interfaces.Domains
{
    public interface ILoginService
    {
        Task<AuthenticateToken> Authenticate(string login, string password);
    }
}
