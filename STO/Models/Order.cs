using System.Collections.ObjectModel;

namespace STO.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public List<Problems> Problems { get; set; }
        public List<Services> Services { get; set; }
        public List<Worker> Workers { get; set; }
        public DateTimeOffset DaTofCreate { get; set; }

        public Order(Client client, List<Problems> problems, List<Services> services, List<Worker> workers)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            Problems = problems ?? throw new ArgumentNullException(nameof(problems));
            Services = services ?? throw new ArgumentNullException(nameof(services));
            Workers = workers ?? throw new ArgumentNullException(nameof(workers));
        }
        public Order()
        {

        }
    }
}
