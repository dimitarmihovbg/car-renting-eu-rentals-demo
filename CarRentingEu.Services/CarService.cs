using AutoMapper;
using CarRentingEu.Dtos;
using CarRentingEu.Models;
using CarRentingEu.Repository;
using CarRentingEu.Repository.Interfaces;
using CarRentingEu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentingEu.Services
{
    public class CarService : ICarService
    {
        private ICarRepository carForServicing;
        private readonly IMapper mapper;

        public CarService(ICarRepository car, IMapper mapper)
        {
            carForServicing = car;
            this.mapper = mapper;
        }

        //CREATE

        public void SaveSingleCar(CarDto carToBeSaved)
        {
            carToBeSaved.NumberAvailable = carToBeSaved.NumberInStock;
            var mappedCarFromDto = mapper.Map<CarDto, Car>(carToBeSaved);
            carForServicing.SaveSingleToDb(mappedCarFromDto); 
        }

        //READ

        public CarDto GetSingleCar(int id)
        {
            var car = carForServicing.GetSingleFromDb(id);
            var mappedDtoCar = mapper.Map<Car, CarDto>(car);
            return mappedDtoCar;
        }

        public IList<CarDto> GetAllCars()
        {
            var allCars = carForServicing.GetAllFromDb();
            var mappedDtoCars = mapper.Map<List<CarDto>>(allCars);
            return mappedDtoCars;
        }

        public IList<ModelDto> GetAllModels()
        {
            var allModels = carForServicing.GetAllModelsFromDb();
            var mappedDtoModels = mapper.Map<List<ModelDto>>(allModels);
            return mappedDtoModels;
        }

        //UPDATE

        public void UpdateSingleCar(CarDto car)
        {
            var mappedCarFromDto = mapper.Map<CarDto, Car>(car);
            carForServicing.UpdateSingleFromDb(mappedCarFromDto);
        }

        //DELETE
       
        public void DeleteSingleCar(CarDto car)
        {
            var mappedCustomerFromDto = mapper.Map<CarDto, Car>(car);
            carForServicing.DeleteSingleFromDb(mappedCustomerFromDto);
        }

    }
}
