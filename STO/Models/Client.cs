using System.Collections.ObjectModel;

namespace STO.Models
{
    public class Client : People
    {
        public required List<Cars> Cars { get; set; }
    }
}
