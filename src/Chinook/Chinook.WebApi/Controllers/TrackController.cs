using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly IRepository<Track> _repository;
        public TrackController(IRepository<Track> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<Track>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(Track))]
        [SwaggerResponse(403, "Forbidden", Type = null)]
        [HttpGet("{trackId}")]
        public async Task<ActionResult<Track>> GetTrack([FromRoute] int trackId)
        {
            var track = await _repository.ReadById(trackId);
            if (track == null) return Forbid();
            return Ok(track);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack([FromBody] Track track)
        {
            await _repository.Create(track);
            return Ok(track.TrackId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutTrack([FromBody] Track track)
        {
            return Ok(await _repository.Update(track));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{trackId}")]
        public async Task<ActionResult<bool>> DeleteTrack([FromRoute] int trackId)
        {
            return Ok(await _repository.Delete(new Track { TrackId = trackId }));
        }
    }
}
