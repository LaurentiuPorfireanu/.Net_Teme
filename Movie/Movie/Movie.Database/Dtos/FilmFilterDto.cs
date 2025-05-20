using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Database.Dtos
{
    public class FilmFilteringDto
    {

        public string? Title { get; set; }
        public int? Year { get; set; }
        public int? DirectorId { get; set; }

        // Pg
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
