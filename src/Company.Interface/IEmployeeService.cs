using Company.Domain;
using Company.Interface.Employees;
using System.Threading.Tasks;

namespace Company.Interface
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(CreateEmployeeDto model);
    }
}
