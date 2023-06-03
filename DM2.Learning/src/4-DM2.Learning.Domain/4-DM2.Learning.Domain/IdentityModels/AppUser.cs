﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DM2.Learning.Domain.IdentityModels
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
