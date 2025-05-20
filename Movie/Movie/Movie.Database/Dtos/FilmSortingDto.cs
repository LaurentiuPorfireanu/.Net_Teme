using Movie.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Database.Dtos
{
    public class FilmSortingDto
    {
        public SortingOrder Order { get; set; } = SortingOrder.Ascending;
        public FilmSortingCriteria Criterion { get; set; } = FilmSortingCriteria.Title;
    }
}
