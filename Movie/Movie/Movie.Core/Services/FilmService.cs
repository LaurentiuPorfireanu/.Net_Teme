using Movie.Core.Dtos.Create;
using Movie.Core.Dtos.View;
using Movie.Core.Mapping;
using Movie.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Services
{
    public class FilmService
    {

        private readonly FilmRepository _filmRepository;

        public FilmService(FilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }


        public async Task<List<FilmDto>> GetAllAsync()
        {
            var films = await _filmRepository.GetAllWithDirectorAsync();
            return films.Select(FilmMapper.ToDto).ToList();
        }


        public async Task<List<FilmDto>> GetByDirectorNameAsync(string directorName)
        {
            var films = await _filmRepository.GetFilmsByDirectorNameAsync(directorName);
            return films.Select(FilmMapper.ToDto).ToList();
        }

        public async Task AddAsync(CreateFilmDto dto)
        {
            var entity = FilmMapper.ToEntity(dto);
            _filmRepository.Insert(entity);
            await _filmRepository.SaveChangesAsync();
        }
    }
}
