using _4_DM2.Learning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _5_DM2.Learning.Infra.Configurations;

public class UserImageConfiguration : IEntityTypeConfiguration<UserImage>
{
    public void Configure(EntityTypeBuilder<UserImage> builder)
    {
        builder.ToTable("UsersImages");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .HasColumnType("varchar(255)")
            .IsRequired(false);

        builder
           .HasOne(user => user.User)
           .WithOne(userImage => userImage.UserImage)
           .HasForeignKey<UserImage>(userImage => userImage.UserId);
    }
}
