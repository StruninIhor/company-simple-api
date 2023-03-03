using Company.Database;
using Company.Domain;
using Company.Interface;
using Company.Interface.Common;
using Company.Interface.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Company.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CompanyDbContext _context;

        public EmployeeService(CompanyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Employee> Create(CreateEmployeeDto model)
        {
            if (model.Salary == 0)
            {
                throw new ModelValidationException("Salary is zero!");
            }
            if (await _context.Departments.AnyAsync(x => x.Id == model.DepartmentId))
            {
                throw new ModelValidationException($"Department ({model.DepartmentId}) was not found!");
            }
            var entry = _context.Employees.Add(new()
            {
                DateOfBirth = model.DateOfBirth,
                DepartmentId = model.DepartmentId,
                Name = model.Name,
                Salary = model.Salary
            });
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
