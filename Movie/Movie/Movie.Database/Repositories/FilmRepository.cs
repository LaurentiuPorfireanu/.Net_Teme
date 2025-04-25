using Movie.Database.Context;
using Movie.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Database.Repositories
{
    public class FilmRepository:BaseRepository<Film>
    {
        public FilmRepository(MovieDatabaseContext context) : base(context)
        {
        }
    }
}
