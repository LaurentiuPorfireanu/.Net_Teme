using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Database.Entities;
using Movie.Infrastructure.Config;



namespace Movie.Database.Context
{
    public class MovieDatabaseContext: DbContext
    {
        public MovieDatabaseContext() { }
        //Conecteaza Ef Core la PostgreSQL si daca ConsoleLogQueries este true
        //va loga queriile in consola
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if(!optionsBuilder.IsConfigured && AppConfig.ConnectionStrings?.MovieDatabase is not null)
            {
                optionsBuilder.UseSqlServer(AppConfig.ConnectionStrings.MovieDatabase);

                if(AppConfig.ConsoleLogQueries)
                {
                    optionsBuilder.LogTo(Console.WriteLine);
                }
            }
        }


        public DbSet<Film> Films { get; set; }
        public DbSet<Director> Directors { get; set; }

    }
}
