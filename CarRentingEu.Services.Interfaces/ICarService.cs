using CarRentingEu.Dtos;
using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Services.Interfaces
{
    public interface ICarService
    {
        //CREATE

        void SaveSingleCar(CarDto carToBeSaved);

        //READ

        CarDto GetSingleCar(int id);

        IList<CarDto> GetAllCars();

        IList<ModelDto> GetAllModels();        

        //UPDATE

        void UpdateSingleCar(CarDto car);

        //DELETE

        void DeleteSingleCar(CarDto car);      
    }
}
