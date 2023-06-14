using _4_DM2.Learning.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace _3_DM2.Learning.Application.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public UserImageViewModel UserImage { get; set; }
    }
}
