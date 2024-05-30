using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Problems> NameOfProblems { get; set; }
        public ObservableCollection<Services> Services { get; set; }
        public ObservableCollection<Worker> Workers { get; set; }
        public DateTimeOffset DaTofCreate { get; set; }

        public Order(ObservableCollection<Problems> nameOfProblems, ObservableCollection<Services> services, ObservableCollection<Worker> workers)
        {
            NameOfProblems = nameOfProblems ?? throw new ArgumentNullException(nameof(nameOfProblems));
            Services = services ?? throw new ArgumentNullException(nameof(services));
            Workers = workers ?? throw new ArgumentNullException(nameof(workers));
        }
    }
}
