using Company.Domain;
using Company.Interface.Departments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Company.Interface
{
    public interface IDepartmentsService
    {
        Task<Department> Create(CreateDepartmentDto model);
        Task<Department> Update(UpdateDepartmentDto model);

        IAsyncEnumerable<Department> Query(int? minEmployees);
    }
}
