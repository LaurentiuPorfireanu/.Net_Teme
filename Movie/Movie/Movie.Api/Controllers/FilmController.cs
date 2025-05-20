using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dtos.Create;
using Movie.Core.Dtos.Update;
using Movie.Core.Services;
using Movie.Database.Dtos;


namespace Movie.Api.Controllers
{
    [ApiController]
    [Route("films")]
    public class FilmController(FilmService _filmService) : ControllerBase
    {


        [HttpPost("add-film")]
        public async Task<IActionResult> AddFilm([FromBody] CreateFilmDto payload)
        {
            await _filmService.AddAsync(payload);
            return Ok("Film added successfully");
        }

        [HttpGet("get-films")]
        public async Task<IActionResult> GetFilms()
        {
            var result = await _filmService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("get-filtered-films")]
        public async Task<IActionResult> GetFilteredFilms([FromQuery] FilmFilteringDto filters, [FromQuery] FilmSortingDto sorting)
        {
            var request = new GetFilteredFilmsRequest
            {
                Filters = filters ?? new FilmFilteringDto(),
                SortingOption = sorting ?? new FilmSortingDto()
            };

            var result = await _filmService.GetFilteredFilmsAsync(request);
            return Ok(result);
        }

        [HttpGet("get-by-director-id/{id}")]
        public async Task<IActionResult> GetByDirectorName(int id)
        {
            var result = await _filmService.GetByDirectirIdAsync(id);
            return Ok(result);


        }

        [HttpGet("get-film/{id}")]
        public async Task<IActionResult> GetFilm(int id)
        {
            var film = await _filmService.GetFilmByIdAsync(id);
            return Ok(film);
        }


        [HttpPatch("update-film/{id}")]
        public async Task<IActionResult> UpdateFilm(int id, [FromBody] UpdateFilmDto payload)
        {
            var updateFilm= await _filmService.UpdateFilmAsync(id, payload);

            if (updateFilm == null)
            {
                return NotFound($"Film with ID {id} not found.");
            }

            return Ok(updateFilm);
        }
    }
}
