using Company.Database;
using Company.Domain;
using Company.Interface;
using Company.Interface.Common;
using Company.Interface.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly CompanyDbContext _context;

        public DepartmentsService(CompanyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Department> Create(CreateDepartmentDto model)
        {
            if (model.Budget == 0)
            {
                throw new ModelValidationException("Budget is zero!");
            }
            var entry = _context.Departments.Add(new()
            {
                Budget = model.Budget,
                HasPrinter = model.HasPrinter,
                Location = model.Location,
                Name = model.Name
            });
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public IAsyncEnumerable<Department> Query(int? minEmployees)
        {
            var query = _context.Departments;
            if (minEmployees != null)
            {
                return query.Where(x => x.Employees.Count() > minEmployees).AsAsyncEnumerable();
            }
            return query.AsAsyncEnumerable();

        }

        public async Task<Department> Update(int id, UpdateDepartmentDto model)
        {
            if (model.Budget == 0)
            {
                throw new ModelValidationException("Budget is zero!");
            }
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
            {
                throw new NotFoundException("Department not found");
            }
            department.Budget = model.Budget;
            department.HasPrinter = model.HasPrinter;
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
