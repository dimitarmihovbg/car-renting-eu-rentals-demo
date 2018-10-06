using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Dtos
{
    public class ModelDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
