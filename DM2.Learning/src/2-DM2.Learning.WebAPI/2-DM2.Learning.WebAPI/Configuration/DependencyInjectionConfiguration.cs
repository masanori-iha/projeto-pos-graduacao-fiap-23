using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.Services;
using _4_DM2.Learning.Domain.Interfaces.Domains;

namespace _2_DM2.Learning.WebAPI.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<ILoginAppService, LoginAppService>();

            return services;
        }
    }
}
