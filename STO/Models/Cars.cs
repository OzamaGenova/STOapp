using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models
{
    public class Cars
    {
        public int Id { get; set; }

        public string Number {  get; set; } = string.Empty;
        public string Model{ get; set; } = string.Empty ;
        public DateTime DateTime { get; set; }  
    }
}
