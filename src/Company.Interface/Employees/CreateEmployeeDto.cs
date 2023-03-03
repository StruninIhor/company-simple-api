using System;
using System.ComponentModel.DataAnnotations;

namespace Company.Interface.Employees
{
    public class CreateEmployeeDto
    {
        [Required(AllowEmptyStrings = false), StringLength(100)]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Salary { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [Required]

        public int DepartmentId { get; set; }
    }
}
