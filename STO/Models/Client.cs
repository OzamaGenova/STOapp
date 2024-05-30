using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models
{
    public class Client : People
    {
        public ObservableCollection<Cars> Cars { get; set; } 
    }
}
