using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    //[Table("Employees")]
    public class Employee : User
    {
        public string? Company { get; set; }
    }

    //[Table("Managers")]
    public class Manager : Employee
    {
        public string? Department { get; set; }
    }
}
