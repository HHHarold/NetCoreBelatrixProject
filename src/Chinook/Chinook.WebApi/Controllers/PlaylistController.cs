using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly IRepository<Playlist> _repository;
        public PlaylistController(IRepository<Playlist> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<Playlist>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(Playlist))]
        [HttpGet("{playlistId}")]
        public async Task<ActionResult<Playlist>> GetPlaylist([FromRoute] int playlistId)
        {
            return Ok(await _repository.ReadById(playlistId));
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist([FromBody] Playlist playlist)
        {
            await _repository.Create(playlist);
            return Ok(playlist.PlaylistId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutPlaylist([FromBody] Playlist playlist)
        {
            return Ok(await _repository.Update(playlist));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{playlistId}")]
        public async Task<ActionResult<bool>> DeletePlaylist([FromRoute] int playlistId)
        {
            return Ok(await _repository.Delete(new Playlist { PlaylistId = playlistId }));
        }
    }
}
