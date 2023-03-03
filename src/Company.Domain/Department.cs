using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Company.Domain
{
    public class Department
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false), StringLength(int.MaxValue, MinimumLength = 10)]
        public string Name { get; set; }

        public string? Location { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Budget { get; set; }

        public bool HasPrinter { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
