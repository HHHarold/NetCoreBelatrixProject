using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IRepository<Invoice> _repository;
        public InvoiceController(IRepository<Invoice> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<Invoice>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(Invoice))]
        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<Invoice>> GetGenre([FromRoute] int invoiceId)
        {
            return Ok(await _repository.ReadById(invoiceId));
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice([FromBody] Invoice invoice)
        {
            await _repository.Create(invoice);
            return Ok(invoice.InvoiceId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutInvoice([FromBody] Invoice invoice)
        {
            return Ok(await _repository.Update(invoice));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{invoiceId}")]
        public async Task<ActionResult<bool>> DeleteInvoice([FromRoute] int invoiceId)
        {
            return Ok(await _repository.Delete(new Invoice { InvoiceId = invoiceId }));
        }
    }
}
