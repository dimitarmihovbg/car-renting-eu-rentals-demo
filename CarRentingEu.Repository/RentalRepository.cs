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
    public class RentalRepository : IRentalRepository
    {
        private ApplicationDbContext _context;

        public RentalRepository()
        {
            _context = new ApplicationDbContext();
        }

        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //CREATE

        public void SaveSingleToDb(Rental rental)
        {
            _context.Rentals.Add(rental);

            _context.SaveChanges();
        }

        //READ

        public Rental GetSingleFromDb(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(c => c.Id == id);
            return rental;
        }

        public IList<Rental> GetAllFromDb()
        {
            var rentals = _context.Rentals.Include(m => m.Car).Include(m => m.Customer).ToList();
            return rentals;
        }

        //UPDATE        

        public void UpdateSingleFromDb(Rental rental)
        {           
              var rentalInDb = _context.Rentals.Single(c => c.Id == rental.Id);
              rentalInDb.DateRented = rental.DateRented;
              rentalInDb.DateReturned = rental.DateReturned;
              rentalInDb.CarId = rental.CarId;
              rentalInDb.CustomerId = rental.CustomerId;            

              _context.SaveChanges();
        }

        //DELETE

        public void DeleteSingleFromDb(Rental rental)
        {
            Rental rentalForDeletion = _context.Rentals.Find(rental.Id);
            _context.Rentals.Remove(rentalForDeletion);

            _context.SaveChanges();
        }

    }
}
