using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Dtos.Update
{
    public class UpdateFilmDto
    {
        public string? Title { get; set; }
        public int? Year { get; set; }
        public int? DirectorId { get; set; }
    }
}
