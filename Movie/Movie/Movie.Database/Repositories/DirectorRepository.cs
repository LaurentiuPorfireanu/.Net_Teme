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
    public class DirectorRepository:BaseRepository<Director>
    {

        private readonly MovieDatabaseContext _context;
        public DirectorRepository(MovieDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Director?> GetDirectorWithFilmsAsync(int id)
        {
            return await _context.Directors
                .Include(d => d.Films)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
    
}

