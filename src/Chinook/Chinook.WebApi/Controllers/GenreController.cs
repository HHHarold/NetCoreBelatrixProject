using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IRepository<Genre> _repository;
        public GenreController(IRepository<Genre> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<Genre>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(Employee))]
        [SwaggerResponse(403, "Forbidden", Type = null)]
        [HttpGet("{genreId}")]
        public async Task<ActionResult<Employee>> GetGenre([FromRoute] int genreId)
        {
            var genre = await _repository.ReadById(genreId);
            if (genre == null) return Forbid();
            return Ok(genre);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre([FromBody] Genre genre)
        {
            await _repository.Create(genre);
            return Ok(genre.GenreId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutGenre([FromBody] Genre genre)
        {
            return Ok(await _repository.Update(genre));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{genreId}")]
        public async Task<ActionResult<bool>> DeleteGenre([FromRoute] int genreId)
        {
            return Ok(await _repository.Delete(new Genre { GenreId = genreId }));
        }
    }
}
