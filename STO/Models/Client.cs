using System.Collections.ObjectModel;

namespace STO.Models
{
    public class Client : People
    {
        public Cars Car { get; set; }
        public Client(string Name, Cars Cars)
        {
            this.Name = Name;
            this.Car = Cars;
            DateTimeOffset DaTofCreate = DateTimeOffset.Now;
        }
        public Client() { } 
    }
}
