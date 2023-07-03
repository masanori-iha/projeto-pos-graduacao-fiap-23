using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.Interfaces;
using _3_DM2.Learning.Application.Services;
using _4_DM2.Learning.Domain.Interfaces.Domains;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using _4_DM2.Learning.Domain.Services;
using _5._1_DM2.Learning.Infra.Azure.Storage.Dtos;
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

            services.AddScoped<IUserImageRepository, UserImageRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserImageAppService, UserImageAppService>();

            services.AddScoped<FileAzureStorageService>();

            return services;
        }
    }
}
