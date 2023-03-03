using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Company.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false), StringLength(100)]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Salary { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
