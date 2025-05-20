using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Movie.Core.Dtos.Create;
using Movie.Core.Dtos.Update;
using Movie.Core.Dtos.View;
using Movie.Core.Mapping;
using Movie.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Infrastructure.Exceptions;

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


        public async Task<List<FilmDto>> GetByDirectirIdAsync(int directorId)
        {
            var films = await _filmRepository.GetFilmsByDirectorAsync(directorId);
            return films.Select(FilmMapper.ToDto).ToList();
        }

        public async Task AddAsync(CreateFilmDto dto)
        {
            var entity = FilmMapper.ToEntity(dto);
            _filmRepository.Insert(entity);
            await _filmRepository.SaveChangesAsync();
        }

        public async Task<GetFilmsResponse> GetFilteredFilmsAsync(GetFilteredFilmsRequest request)
        {
            var (films, totalCount) = await _filmRepository.GetFilteredFilmsAsync(request.Filters, request.SortingOption);

            var response = new GetFilmsResponse
            {
                Films = films.Select(FilmMapper.ToDto).ToList(),
                TotalCount = totalCount
            };

            return response;
        }

        public async Task<FilmDto?> UpdateFilmAsync(int id, UpdateFilmDto updateDto)
        {
            var film = await _filmRepository.GetByIdWithDirectorAsync(id);

           
            if (film == null)
            {
                throw new ResourceNotFoundException($"Film with ID {id} not found.");
            }

          
            if (updateDto.Title != null)
            {
                film.Title = updateDto.Title;
            }

            if (updateDto.Year.HasValue)
            {
                film.Year = updateDto.Year.Value;
            }

            if (updateDto.DirectorId.HasValue)
            {
                film.DirectorId = updateDto.DirectorId.Value;
            }

          
            film.UpdatedAt = DateTime.UtcNow;

            
            _filmRepository.UpdateFilm(film);
            await _filmRepository.SaveChangesAsync();

           
            var updatedFilm = await _filmRepository.GetByIdWithDirectorAsync(id);

            return updatedFilm != null ? FilmMapper.ToDto(updatedFilm) : null;
        }

        public async Task<FilmDto> GetFilmByIdAsync(int id)
        {
            var film = await _filmRepository.GetByIdWithDirectorAsync(id);

            if (film == null)
            {
                throw new ResourceNotFoundException($"Film with ID {id} not found.");
            }

            return FilmMapper.ToDto(film);
        }

    }
}
