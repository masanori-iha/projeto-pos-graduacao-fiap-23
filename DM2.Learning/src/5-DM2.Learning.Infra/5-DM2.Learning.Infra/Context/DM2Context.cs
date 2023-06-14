using _4_DM2.Learning.Domain.Entities;
using _5_DM2.Learning.Infra.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_DM2.Learning.Infra.Context
{
    public class DM2Context : DbContext
    {
        public DM2Context(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(userImage => userImage.UserImage)
                .WithOne(user => user.User);

            builder.Entity<UserImage>()
               .HasOne(user => user.User)
               .WithOne(userImage => userImage.UserImage)
               .HasForeignKey<UserImage>(userImage => userImage.UserId);

            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserImage> UsersImages { get; set; }
    }
}
