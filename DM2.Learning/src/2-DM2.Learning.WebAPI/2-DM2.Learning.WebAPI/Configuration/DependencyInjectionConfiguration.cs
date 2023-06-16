using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.Services;
using _4_DM2.Learning.Domain.Interfaces.Domains;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using _5_DM2.Learning.Infra.Repositories;

namespace _2_DM2.Learning.WebAPI.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IUserService, UserService>();


            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
