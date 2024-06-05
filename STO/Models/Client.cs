using System.Collections.ObjectModel;

namespace STO.Models
{
    public class Client : People
    {
        public List<Cars> Cars { get; set; }
        public Client(string Name)
        {
            this.Name = Name;
            DateTimeOffset DaTofCreate = DateTimeOffset.Now;
        }
    }
}
