using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models
{
    public class Worker : People
    {
        public decimal Salary { get; set; }
        public Worker(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
            DateTimeOffset DaTofCreate = DateTimeOffset.Now;
        }
        public Worker() { }
    }
}
