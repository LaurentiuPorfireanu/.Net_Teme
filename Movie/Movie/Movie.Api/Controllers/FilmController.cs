using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dtos.Create;
using Movie.Core.Services;


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

        [HttpGet("get-by-director-id/{id}")]
        public async Task<IActionResult> GetByDirectorName(int id)
        {
            var result = await _filmService.GetByDirectirIdAsync(id);
            return Ok(result);


        }
    }
}
