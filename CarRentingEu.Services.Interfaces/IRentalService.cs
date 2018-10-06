using CarRentingEu.Dtos;
using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Services.Interfaces
{
    public interface IRentalService
    {
        //CREATE

        void SaveSingleRental(RentalDto rental);

        //READ

        RentalDto GetSingleRental(int id);

        IList<RentalDto> GetAllRentals();

        //UPDATE

        void UpdateSingleRental(RentalDto rental);

        //DELETE

        void DeleteSingleRental(RentalDto rental);
    }
}
