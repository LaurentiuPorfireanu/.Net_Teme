

using Microsoft.Extensions.DependencyInjection;
using Movie.Database.Context;
using Movie.Database.Repositories;

namespace Movie.Database
{
    public static class DIConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<MovieDatabaseContext>();
            services.AddScoped<FilmRepository>();
            services.AddScoped<DirectorRepository>();

            return services;
        }
    }
}
