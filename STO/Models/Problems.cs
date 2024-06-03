using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models
{
    public class Problems
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0, int.MaxValue)]
        public double Cost { get; set; }
        [Required]
        public DateTimeOffset DaTofCreate { get; set; }

        public Problems(string title, string description, double cost)
        {
            Title = title;
            Description = description;
            Cost = cost;
        }
        public Problems() { }
    }
}
