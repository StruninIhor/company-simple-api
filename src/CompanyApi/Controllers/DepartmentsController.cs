using Company.Domain;
using Company.Interface;
using Company.Interface.Common;
using Company.Interface.Departments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentsController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService ?? throw new ArgumentNullException(nameof(departmentsService));
        }

        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(CreateDepartmentDto department) => Ok(await _departmentsService.Create(department));
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Department>> UpdateDepartment(UpdateDepartmentDto department) => Ok(await _departmentsService.Update(department));
        [HttpGet]
        public ActionResult<Department> GetDepartments([FromQuery] int minEmployees) => Ok(_departmentsService.Query(minEmployees));
    }
}
