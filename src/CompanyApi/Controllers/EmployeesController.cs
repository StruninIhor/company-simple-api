using Company.Domain;
using Company.Interface;
using Company.Interface.Common;
using Company.Interface.Employees;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeDto employee)
        {
            try
            {
                return Ok(await _employeeService.Create(employee));
            }
            catch (ModelValidationException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
