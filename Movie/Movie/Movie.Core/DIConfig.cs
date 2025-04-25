using Microsoft.Extensions.DependencyInjection;
using Movie.Core.Services;

namespace Movie.Core
{
    public static class DIConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<FilmService>();
            services.AddScoped<DirectorService>();


            return services;
        }
    }

}