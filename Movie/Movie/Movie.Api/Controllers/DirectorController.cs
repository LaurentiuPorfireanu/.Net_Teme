using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dtos.Create;
using Movie.Core.Services;

namespace Movie.Api.Controllers
{
    [ApiController]
    [Route("directors")]
    public class DirectorController:ControllerBase
    {
        private readonly DirectorService _service;

        public DirectorController(DirectorService service)
        {
            _service = service;
        }

        [HttpPost("add-director")]
        public async Task<IActionResult> AddDirector([FromBody] CreateDirectorDto dto)
        {
            await _service.AddAsync(dto);
            return Ok("Director added successfully");
        }
             



        [HttpGet("get-directors.")]
        public async Task<IActionResult> GetDirectors()
        {
            var directors = await _service.GetAllAsync();
            return Ok(directors);
        }


        
    }
}
