using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Dtos.View
{
    public class GetFilmsResponse
    {
        public List<FilmDto> Films { get; set; } = new List<FilmDto>();
        public int TotalCount { get; set; }
    }
}
