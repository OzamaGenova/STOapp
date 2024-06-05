﻿using System;
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
        public int CarVin { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public DateTimeOffset DaTofCreate { get; set; }

        public Cars(string make, string model, int carVin, int year, string color)
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
