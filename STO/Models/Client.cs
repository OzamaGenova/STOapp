using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models
{
    public class Client : People
    {
        public int CarsId {  get; set; }
        public virtual required Cars Cars { get; set; } 
    }
}
