using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Film>> GetAllWithDirectorAsync()
        {
            return await _dbSet
                .Include(f => f.Director)
                .Where(f => f.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<List<Film>> GetFilmsByDirectorNameAsync(string directorName)
        {
            return await _dbSet
                .Include(f => f.Director)
                .Where(f => f.DeletedAt == null && f.Director.Name == directorName)
                   .ToListAsync();
        }

    }
}
