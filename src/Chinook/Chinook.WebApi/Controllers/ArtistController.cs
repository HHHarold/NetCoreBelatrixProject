using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IRepository<Artist> _repository;
        public ArtistController(IRepository<Artist> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<Artist>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(Artist))]
        [HttpGet("{artistId}")]
        public async Task<ActionResult<Artist>> GetArtist([FromRoute] int artistId)
        {
            return Ok(await _repository.ReadById(artistId));
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist([FromBody]Artist artist)
        {
            await _repository.Create(artist);
            return Ok(artist.ArtistId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutArtist([FromBody] Artist artist)
        {
            return Ok(await _repository.Update(artist));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{artistId}")]
        public async Task<ActionResult<bool>> DeleteArtist([FromRoute] int artistId)
        {
            return Ok(await _repository.Delete(new Artist { ArtistId = artistId }));
        }
    }
}
