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
    public static  class DirectorMapper
    {
        public static DirectorDto ToDto(Director director)
        {
            return new DirectorDto
            {
                Id = director.Id,
                Name = director.Name
            };
        }

        public static Director ToEntity(CreateDirectorDto dto)
        {
            return new Director
            {
                Name = dto.Name
            };
        }
        }
}

