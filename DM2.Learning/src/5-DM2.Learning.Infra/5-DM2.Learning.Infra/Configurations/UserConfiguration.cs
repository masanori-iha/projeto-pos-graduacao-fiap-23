using _4_DM2.Learning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _5_DM2.Learning.Infra.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder
            .HasOne(userImage => userImage.UserImage)
            .WithOne(user => user.User);
    }
}
