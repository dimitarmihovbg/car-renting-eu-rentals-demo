using AutoMapper;
using CarRentingEu.Dtos;
using CarRentingEu.Models;
using CarRentingEu.Data;
using CarRentingEu.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentingEu.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper mapper;
        private ApplicationDbContext _context;

        public CarService(IMapper mapper, ApplicationDbContext _context)
        {
            this.mapper = mapper;
            this._context = _context;
        }

        public void SaveSingleCar(CarDto carToBeSaved)
        {
            carToBeSaved.NumberAvailable = carToBeSaved.NumberInStock;

            var mappedCarFromDto = mapper.Map<CarDto, Car>(carToBeSaved);

            _context.Cars.Add(mappedCarFromDto);

            _context.SaveChanges();
        }

        public CarDto GetSingleCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            var mappedDtoCar = mapper.Map<Car, CarDto>(car);

            return mappedDtoCar;
        }

        public IList<CarDto> GetAllCars()
        {
            var allCars = _context.Cars.Include(m => m.Model).ToList();

            var mappedDtoCars = mapper.Map<List<CarDto>>(allCars);

            return mappedDtoCars;
        }

        public IList<ModelDto> GetAllModels()
        {
            var allModels = _context.Models.ToList();

            var mappedDtoModels = mapper.Map<List<ModelDto>>(allModels);

            return mappedDtoModels;
        }

        public void UpdateSingleCar(CarDto car)
        {
            var carInDb = _context.Cars.Single(m => m.Id == car.Id);

            carInDb.Name = car.Name;
            carInDb.ModelId = car.ModelId;
            carInDb.NumberInStock = car.NumberInStock;
            carInDb.ReleaseDate = car.ReleaseDate;

            _context.SaveChanges();
        }
       
        public void DeleteSingleCar(CarDto car)
        {          
            var carForDeletion = _context.Cars.Find(car.Id);

            _context.Cars.Remove(carForDeletion);

            _context.SaveChanges();           
        }
    }
}
