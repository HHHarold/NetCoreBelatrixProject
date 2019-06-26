using Chinook.WebApi.Filters;
using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;
        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<Customer>))]
        [HttpGet]
        [CustomerResultFilter]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(Customer))]
        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomer([FromRoute] int customerId)
        {
            return Ok(await _repository.ReadById(customerId));
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer([FromBody] Customer customer)
        {
            await _repository.Create(customer);
            return Ok(customer.CustomerId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutCustomer([FromBody] Customer customer)
        {
            return Ok(await _repository.Update(customer));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{customerId}")]
        public async Task<ActionResult<bool>> DeleteCustomer([FromRoute] int customerId)
        {
            return Ok(await _repository.Delete(new Customer { CustomerId = customerId }));
        }
    }
}
