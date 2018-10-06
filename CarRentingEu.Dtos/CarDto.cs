using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentingEu.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Model Model { get; set; }

        public byte ModelId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}
