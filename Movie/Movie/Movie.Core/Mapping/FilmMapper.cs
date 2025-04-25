using Movie.Core.Dtos.Create;
using Movie.Core.Dtos.View;
using Movie.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Mapping
{
    public static class FilmMapper
    {
        public static FilmDto ToDto(Film film)
        {
            return new FilmDto
            {
                Id = film.Id,
                Title = film.Title,
                Year=film.Year,
                DirectorName = film.Director.Name
            };
        }

        public static Film ToEntity(CreateFilmDto dto)
        {
            return new Film
            {
                Title = dto.Title,
                Year = dto.Year,
                DirectorId = dto.DirectorId
            };
        }
    }
}
