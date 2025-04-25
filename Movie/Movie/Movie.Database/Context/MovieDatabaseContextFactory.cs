using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Movie.Database.Context;
using Movie.Infrastructure.Config;
using Microsoft.Extensions.DependencyInjection;

namespace Movie.Database.Context
{
    internal class MovieDatabaseContextFactory : IDesignTimeDbContextFactory<MovieDatabaseContext>
    {
        public MovieDatabaseContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            AppConfig.Init(configuration);

            return new MovieDatabaseContext();
        }
    }
    
    
}
