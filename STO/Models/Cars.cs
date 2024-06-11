using System.ComponentModel.DataAnnotations;

namespace STO.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string CarVin { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public DateTimeOffset DaTofCreate { get; set; }

        public Cars(string make, string model, string carVin, int year, string color)
        {
            this.Make = make;
            this.Model = model;
            this.CarVin = carVin;
            this.Year = year;
            this.Color = color;
            DateTimeOffset DaTofCreate = DateTimeOffset.Now;
        }
        public Cars() { }
    }
}
