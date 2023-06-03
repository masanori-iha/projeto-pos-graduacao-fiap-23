using _4_DM2.Learning.Domain.IdentityModels;
using _5_DM2.Learning.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _2_DM2.Learning.WebAPI.Configuration
{
    public static class IdentityConfiguration
    {
        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DM2IdentityContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DM2IdentityConnection"));
            });

            var builder = services.AddIdentity<AppUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = true;
                o.Password.RequireNonAlphanumeric = true;
                o.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<DM2IdentityContext>()
              .AddDefaultTokenProviders();
        }
    }
}
