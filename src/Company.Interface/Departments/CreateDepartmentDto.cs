using System;
using System.ComponentModel.DataAnnotations;

namespace Company.Interface.Departments
{
    public class CreateDepartmentDto
    {
        [Required(AllowEmptyStrings = false), StringLength(int.MaxValue, MinimumLength = 10)]
        public string Name { get; set; }

        public string? Location { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Budget { get; set; }

        public bool HasPrinter { get; set; }
    }
}
