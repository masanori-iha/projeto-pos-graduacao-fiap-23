using _4_DM2.Learning.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace _4_DM2.Learning.Domain.IdentityModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public UserImage UserImage { get; set; }
    }
}
