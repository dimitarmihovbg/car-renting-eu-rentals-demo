using CarRentingEu.Dtos;
using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Repository.Interfaces
{
    public interface IRentalRepository
    {
        //CREATE

        void SaveSingleToDb(Rental rental);

        //READ

        Rental GetSingleFromDb(int id);

        IList<Rental> GetAllFromDb();

        //UPDATE

        void UpdateSingleFromDb(Rental rental);

        //DELETE

        void DeleteSingleFromDb(Rental rental);       
    }
}
