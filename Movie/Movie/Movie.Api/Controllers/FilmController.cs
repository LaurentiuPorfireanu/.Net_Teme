using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dtos.Create;
using Movie.Core.Services;


namespace Movie.Api.Controllers
{
    [ApiController]
    [Route("films")]
    public class FilmController:ControllerBase
    {
        private readonly FilmService _filmService;

        public FilmController(FilmService filmService)
        {
            _filmService = filmService;
        }

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

        [HttpGet("get-film/{id}")]
        public async Task<IActionResult> GetFilm(int id)
        {
           var result = await _filmService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Film not found");
            }
            return Ok(result);
        }
    }
}
