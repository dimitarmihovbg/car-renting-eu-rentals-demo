using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentingEu.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        public Customer Customer { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }
    }
}
