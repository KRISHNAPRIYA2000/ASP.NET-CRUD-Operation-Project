using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
