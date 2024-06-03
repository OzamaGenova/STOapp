using System.Collections.ObjectModel;

namespace STO.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required List<Client> Clients { get; set; }
        public required List<Problems> Problems { get; set; }
        public required List<Services> Services { get; set; }
        public required List<Worker> Workers { get; set; }
        public DateTimeOffset DaTofCreate { get; set; }

        public Order(List<Problems> nameOfProblems, List<Services> services, List<Worker> workers)
        {
            Problems = nameOfProblems ?? throw new ArgumentNullException(nameof(nameOfProblems));
            Services = services ?? throw new ArgumentNullException(nameof(services));
            Workers = workers ?? throw new ArgumentNullException(nameof(workers));
        }
        public Order()
        {

        }
    }
}
