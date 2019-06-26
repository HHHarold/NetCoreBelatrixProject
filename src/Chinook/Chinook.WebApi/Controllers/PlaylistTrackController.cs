using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PlaylistTrackController : ControllerBase
    {
        private readonly IRepository<PlaylistTrack> _repository;
        public PlaylistTrackController(IRepository<PlaylistTrack> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<PlaylistTrack>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistTrack>>> GetPlaylistTracks()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(PlaylistTrack))]
        [SwaggerResponse(403, "Forbidden", Type = null)]
        [HttpGet("{playlistId}")]
        public async Task<ActionResult<PlaylistTrack>> GetPlaylistTrack([FromRoute] int playlistId, int trackId)
        {
            var playlistTrack = await _repository.ReadById(new { playlistId, trackId });
            if (playlistTrack == null) return Forbid();
            return Ok(playlistTrack);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<PlaylistTrack>> PostPlaylistTrack([FromBody] PlaylistTrack PlaylistTrack)
        {
            await _repository.Create(PlaylistTrack);
            return Ok(new { PlaylistTrack.PlaylistId, PlaylistTrack.TrackId });
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutPlaylistTrack([FromBody]  PlaylistTrack PlaylistTrack)
        {
            return Ok(await _repository.Update(PlaylistTrack));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("playlist/{playlistId}/track/{trackId}")]
        public async Task<ActionResult<bool>> DeletePlaylistTrack([FromRoute] int playlistId, int trackId)
        {
            return Ok(await _repository.Delete(new PlaylistTrack { PlaylistId = playlistId, TrackId = trackId }));
        }
    }
}
