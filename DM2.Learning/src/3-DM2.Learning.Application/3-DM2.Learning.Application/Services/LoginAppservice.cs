using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DM2.Learning.Application.Services
{
    public class LoginAppservice : ILoginAppService
    {
        public Task<AuthenticateTokenViewModel> Authenticate(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
