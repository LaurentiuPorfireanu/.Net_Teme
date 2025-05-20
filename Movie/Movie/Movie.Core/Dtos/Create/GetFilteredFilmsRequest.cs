using Movie.Database.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Movie.Core.Dtos.Create
{
    public class GetFilteredFilmsRequest
    {
        public FilmFilteringDto Filters { get; set; } = new FilmFilteringDto();

        public FilmSortingDto SortingOption { get; set; } = new FilmSortingDto();
    }
}
