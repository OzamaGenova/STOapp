using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models
{
    class Client:People
    {
        List<Cars> car { get; set; } = new List<Cars>();
    }
}
