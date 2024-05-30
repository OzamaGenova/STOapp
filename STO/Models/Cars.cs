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
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Car_Vin { get; set; }
        [Required]
        public int Year { get; set; }
        public string Color { get; set; }
        [Required]
        public DateTimeOffset DaTofCreate { get; set; }

        public Cars(string make, string model, int carVin, int year, string color)
        {
            Make = make;
            Model = model;
            Car_Vin = carVin;
            Year = year;
            Color = color;
        }
    }
}
