using _4_DM2.Learning.Domain.Entities;
using _5_DM2.Learning.Infra.Configurations;
using Microsoft.EntityFrameworkCore;

namespace _5_DM2.Learning.Infra.Context;

public class DM2Context : DbContext
{
    public DM2Context(DbContextOptions options) : base(options) { }


    public DbSet<User> Users { get; set; }
    public DbSet<UserImage> UsersImages { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new UserImageConfiguration());
    }
}
