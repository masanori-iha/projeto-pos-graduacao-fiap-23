using _3_DM2.Learning.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DM2.Learning.Application.interfaces
{
    public interface ILoginAppService
    {
        Task<AuthenticateTokenViewModel> Authenticate(string login,  string password);
    }
}
