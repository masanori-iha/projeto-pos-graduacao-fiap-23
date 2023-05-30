using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DM2.Learning.Domain.Models
{
    public class AuthenticateToken
    {
        public AuthenticateToken(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}
