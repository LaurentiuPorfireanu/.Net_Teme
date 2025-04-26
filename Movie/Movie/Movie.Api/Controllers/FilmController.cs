using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dtos.Create;
using Movie.Core.Services;


namespace Movie.Api.Controllers
{
    [ApiController]
    [Route("films")]
    public class FilmController(FilmService _filmService) :ControllerBase
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
           var result= await _filmService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("get-by-director-name/{name}")]
        public async Task<IActionResult> GetByDirectorName(string name)
        {
            var result = await _filmService.GetByDirectorNameAsync(name);
            return Ok(result);
        }

    }
}
