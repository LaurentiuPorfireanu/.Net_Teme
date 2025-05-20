using Microsoft.EntityFrameworkCore;
using Movie.Database.Context;
using Movie.Database.Dtos;
using Movie.Database.Entities;
using Movie.Database.QueryExtensions;
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

        public async Task<List<Film>> GetFilmsByDirectorAsync(int id)
        {
            return await _dbSet.
                Include(f => f.Director).Where(f=>f.DeletedAt==null && f.DirectorId == id).
                ToListAsync();
        }

        public async Task<(List<Film> Films, int TotalCount)> GetFilteredFilmsAsync(
           FilmFilteringDto filters,
           FilmSortingDto sortingOption)
        {
            var query = _dbSet
                .Include(f => f.Director)
                .Where(f => f.DeletedAt == null)
                .FilterByTitle(filters.Title)
                .FilterByYear(filters.Year)
                .FilterByDirectorId(filters.DirectorId);

           
            var totalCount = await query.CountAsync();

            
            var films = await query
                .SortBy(sortingOption)
                .Skip(filters.Skip)
                .Take(filters.Take)
                .ToListAsync();

            return (films, totalCount);
        }

        public async Task<Film?> GetByIdWithDirectorAsync(int id)
        {
            return await _dbSet.
                Include(f=>f.Director)
                .FirstOrDefaultAsync(f=>f.Id== id && f.DeletedAt == null);
        }

        public void UpdateFilm(Film film)
        {
            Update(film);
        }

    }
}
