using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MediaTypeController : ControllerBase
    {
        private readonly IRepository<MediaType> _repository;
        public MediaTypeController(IRepository<MediaType> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<MediaType>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaType>>> GetMediaTypes()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(MediaType))]
        [HttpGet("{mediaTypeId}")]
        public async Task<ActionResult<MediaType>> GetMediaType([FromRoute] int mediaTypeId)
        {
            return Ok(await _repository.ReadById(mediaTypeId));
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<MediaType>> PostMediaType([FromBody] MediaType mediaType)
        {
            await _repository.Create(mediaType);
            return Ok(mediaType.MediaTypeId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutMediaType([FromBody] MediaType mediaType)
        {
            return Ok(await _repository.Update(mediaType));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{mediaTypeId}")]
        public async Task<ActionResult<bool>> DeleteMediaType([FromRoute] int mediaTypeId)
        {
            return Ok(await _repository.Delete(new MediaType { MediaTypeId = mediaTypeId }));
        }
    }
}
