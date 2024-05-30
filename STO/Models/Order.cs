using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required List<Problems> NameOfProblems { get; set; }
        public virtual List<Services> Services { get; set; }
        public virtual List<Worker> Workers { get; set; }
        public DateTimeOffset DaTofCreate { get; set; }

        public Order(List<Problems> nameOfProblems,  List<Services> services,  List<Worker> workers)
        {
            NameOfProblems = nameOfProblems ?? throw new ArgumentNullException(nameof(nameOfProblems));
            Services = services ?? throw new ArgumentNullException(nameof(services));
            Workers = workers ?? throw new ArgumentNullException(nameof(workers));
        }
    }
}
