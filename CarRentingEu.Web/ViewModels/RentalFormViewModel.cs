using CarRentingEu.Dtos;
using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentingEu.Web.ViewModels
{
    public class RentalFormViewModel
    {     
        public IEnumerable<CustomerDto> Customers { get; set; }

        public IEnumerable<CarDto> Cars { get; set; }

        public IEnumerable<ModelDto> Models { get; set; }

        public int? Id { get; set; }

        public int? CustomerId { get; set; }

        public int? CarId { get; set; }

        public DateTime DateRented { get; set; }

        [DisplayFormat(NullDisplayText = "231")]
        public DateTime? DateReturned { get; set; }

        public RentalFormViewModel()
        {
            Id = 0;
        }

        public RentalFormViewModel(RentalDto rental)
        {
            Id = rental.Id;
            CustomerId = rental.CustomerId;
            CarId = rental.CarId;
            DateRented = rental.DateRented;
            DateReturned = rental.DateReturned;
        }
    }
}
