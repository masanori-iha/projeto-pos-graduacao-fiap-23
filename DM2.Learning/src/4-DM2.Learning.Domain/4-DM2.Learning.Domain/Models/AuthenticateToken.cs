using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DM2.Learning.Domain.Models
{
    public class AuthenticateToken
    {
        public bool Authenticate { get; set; }
        public string? Token { get; set; }
    }
}
