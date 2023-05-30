using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DM2.Learning.Application.ViewModels
{
    public class AuthenticateTokenViewModel
    {
        public AuthenticateTokenViewModel(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}
