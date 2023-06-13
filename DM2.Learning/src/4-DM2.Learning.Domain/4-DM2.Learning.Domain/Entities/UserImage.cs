using _4_DM2.Learning.Domain.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DM2.Learning.Domain.Entities
{
    public class UserImage
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
