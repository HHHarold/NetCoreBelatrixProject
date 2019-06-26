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
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        [SwaggerResponse(200, "Success", typeof(IEnumerable<Employee>))]
        [HttpGet]
        [EmployeeResultFilter]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _repository.Read());
        }

        [SwaggerResponse(200, "Success", typeof(Employee))]
        [SwaggerResponse(403, "Forbidden", Type = null)]
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Employee>> GetEmployee([FromRoute] int employeeId)
        {
            var employee = await _repository.ReadById(employeeId);
            if (employee == null) return Forbid();
            return Ok(employee);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] Employee employee)
        {
            await _repository.Create(employee);
            return Ok(employee.EmployeeId);
        }

        [SwaggerResponse(200, "Success")]
        [HttpPut]
        public async Task<ActionResult<bool>> PutEmployee([FromBody] Employee employee)
        {
            return Ok(await _repository.Update(employee));
        }

        [SwaggerResponse(200, "Success")]
        [HttpDelete("{employeeId}")]
        public async Task<ActionResult<bool>> DeleteEmployee([FromRoute] int employeeId)
        {
            return Ok(await _repository.Delete(new Employee { EmployeeId = employeeId }));
        }
    }
}
