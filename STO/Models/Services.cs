using System.ComponentModel.DataAnnotations;


namespace STO.Models
{
    public class Services
    {
        public int Id { get; set; }
        [Required]
        public string Services_Title { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Services_Cost { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Services_TimeOfExecution { get; set; }
        [Required]
        public DateTimeOffset DaTOfCreate { get; set; }

        public Services(string title, double cost, int time)
        {
            Services_Title = title;
            Services_Cost = cost;
            Services_TimeOfExecution = time;
        }
        public Services() { }
    }
}
