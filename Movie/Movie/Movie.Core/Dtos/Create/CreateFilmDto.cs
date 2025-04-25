using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Dtos.Create
{
    public class CreateFilmDto
    {
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }

        public int DirectorId { get; set; }

    }
}
