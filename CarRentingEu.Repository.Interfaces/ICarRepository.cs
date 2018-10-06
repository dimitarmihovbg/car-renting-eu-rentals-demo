using CarRentingEu.Dtos;
using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Repository.Interfaces
{
    public interface ICarRepository
    {
        //CREATE

        void SaveSingleToDb(Car carToBeSaved);

        //READ

        Car GetSingleFromDb(int id);

        IList<Car> GetAllFromDb();

        IList<Model> GetAllModelsFromDb();

        //UPDATE

        void UpdateSingleFromDb(Car car);

        //DELETE

        void DeleteSingleFromDb(Car car);
    }
}
