using System;
using System.ComponentModel.DataAnnotations;

namespace Company.Interface.Departments
{
    public class UpdateDepartmentDto
    {

        [Range(0, int.MaxValue)]
        public decimal Budget { get; set; }

        public bool HasPrinter { get; set; }
    }
}
