using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceLineController : ControllerBase
    {
        private readonly IRepository<InvoiceLine> _repository;
        public InvoiceLineController(IRepository<InvoiceLine> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<InvoiceLine>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceLine>>> GetInvoiceLines()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(InvoiceLine))]
        [SwaggerResponse(403, "Forbidden", Type = null)]
        [HttpGet("{invoiceLineId}")]
        public async Task<ActionResult<InvoiceLine>> GetInvoiceLine([FromRoute] int invoiceLineId)
        {
            var invoiceLine = await _repository.ReadById(invoiceLineId);
            if (invoiceLine == null) return Forbid();
            return Ok(invoiceLine);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<InvoiceLine>> PostInvoiceLine([FromBody] InvoiceLine invoiceLine)
        {
            await _repository.Create(invoiceLine);
            return Ok(invoiceLine.InvoiceLineId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutInvoiceLine([FromBody] InvoiceLine invoiceLine)
        {
            return Ok(await _repository.Update(invoiceLine));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{invoiceLineId}")]
        public async Task<ActionResult<bool>> DeleteInvoiceLine([FromRoute] int invoiceLineId)
        {
            return Ok(await _repository.Delete(new InvoiceLine { InvoiceLineId = invoiceLineId }));
        }
    }
}
