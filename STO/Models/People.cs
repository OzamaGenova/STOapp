using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public DateTime DaTofCreate { get; set; }
    }
}
