using _4_DM2.Learning.Domain.Entities;
using _5._1_DM2.Learning.Infra.Azure.Storage.Dtos;
using _6_DM2.Learning.Infra.WeAPI.Models;

namespace _1_DM2.Learning.Presentation.Configurations
{
    public static class DependencyInjectionConfigurationscs
    {
        public static IServiceCollection DependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<UserControllerWebApi>();
            services.AddScoped<UserImageControllerWebApi>();
            services.AddScoped<FileAzureStorageService>();

            return services;
        }
    }
}
