using _4_DM2.Learning.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_DM2.Learning.Infra.Context
{
    public class DM2IdentityContext : IdentityDbContext<AppUser>
    {
        public DM2IdentityContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
