using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IRepository<Album> _repository;
        public AlbumController(IRepository<Album> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<Album>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(Album))]
        [SwaggerResponse(403, "Forbidden", Type = null)]
        [HttpGet("{albumId}")]
        public async Task<ActionResult<Album>> GetAlbum([FromRoute] int albumId)
        {
            var album = await _repository.ReadById(albumId);
            if (album == null) return Forbid();
            return Ok(album);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum([FromBody] Album album)
        {
            await _repository.Create(album);
            return Ok(album.AlbumId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutAlbum([FromBody] Album album)
        {
            return Ok(await _repository.Update(album));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{albumId}")]        
        public async Task<ActionResult<bool>> DeleteAlbum([FromRoute] int albumId)
        {
            return Ok(await _repository.Delete(new Album { AlbumId = albumId }));
        }
    }
}
