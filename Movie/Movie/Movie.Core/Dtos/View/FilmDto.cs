using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Dtos.View
{
    public  class FilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public int Year { get; set; }
        public string DirectorName { get; set; } = string.Empty;
       
    }
}
