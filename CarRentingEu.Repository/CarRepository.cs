using CarRentingEu.Dtos;
using CarRentingEu.Models;
using CarRentingEu.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRentingEu.Repository
{
    public class CarRepository : ICarRepository
    {

        private ApplicationDbContext _context;

        public CarRepository()
        {
            _context = new ApplicationDbContext();
        }

        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //CREATE

        public void SaveSingleToDb(Car carToBeSaved)
        {
            _context.Cars.Add(carToBeSaved);

            _context.SaveChanges();
        }

        //READ

        public Car GetSingleFromDb(int id)
        {
                var car = _context.Cars.SingleOrDefault(c => c.Id == id);
                return car;
        }

        public IList<Car> GetAllFromDb()
        {
            var cars = _context.Cars.Include(m => m.Model).ToList();
            return cars;
        }           

        public IList<Model> GetAllModelsFromDb()
        {
            var models = _context.Models.ToList();
            return models;
        }       

        //UPDATE            

        public void UpdateSingleFromDb(Car car)
        {
            var carInDb = _context.Cars.Single(m => m.Id == car.Id);
            carInDb.Name = car.Name;
            carInDb.ModelId = car.ModelId;
            carInDb.NumberInStock = car.NumberInStock;
            carInDb.ReleaseDate = car.ReleaseDate;

            _context.SaveChanges();
        }

        public void ReturnCarAvailable(int id)
        {
            _context.Cars.Single(c => c.Id == id).NumberAvailable++;

            _context.SaveChanges();
        }

        public void RemoveCarAvailable(int id)
        {
            _context.Cars.Single(c => c.Id == id).NumberAvailable--;

            _context.SaveChanges();
        }

        //DELETE

        public void DeleteSingleFromDb(Car car)
        {
                Car carForDeletion = _context.Cars.Find(car.Id);
                _context.Cars.Remove(carForDeletion);

                _context.SaveChanges();
        }        
    }
}
