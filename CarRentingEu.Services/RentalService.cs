using AutoMapper;
using CarRentingEu.Dtos;
using CarRentingEu.Data;
using CarRentingEu.Models;
using CarRentingEu.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarRentingEu.Services
{
    public class RentalService : IRentalService
    {
        private ApplicationDbContext _context;
        private readonly IMapper mapper;

        public RentalService(IMapper mapper, ApplicationDbContext _context)
        {
            this._context = _context;
            this.mapper = mapper;
        }

        public void SaveSingleRental(RentalDto rental)
        {
            if (rental.DateReturned == null)
            {
                _context.Cars.Find(rental.Id).NumberAvailable--;

                _context.SaveChanges();              
            }

            var mappedRentalFromDto = mapper.Map<RentalDto, Rental>(rental);

            _context.Rentals.Add(mappedRentalFromDto);

            _context.SaveChanges();          
        }

        public RentalDto GetSingleRental(int id)
        {
            var rental = _context.Rentals.Find(id);

            var mappedRentalDto = mapper.Map<Rental, RentalDto>(rental);

            return mappedRentalDto;
        }

        public IList<RentalDto> GetAllRentals()
        {
            var rentals = _context.Rentals.Include(m => m.Car).Include(m => m.Customer).ToList();

            var mappedDtoRentals = mapper.Map<List<RentalDto>>(rentals);

            return mappedDtoRentals;
        }        

        public void UpdateSingleRental(RentalDto rental)
        {
            var rentalInDb = _context.Rentals.Find(rental.Id);

            if (rentalInDb.DateReturned == null & rental.DateReturned != null)
            {
                _context.Cars.Find(rental.CarId).NumberAvailable++;

                _context.SaveChanges();
            }

            rentalInDb.DateRented = rental.DateRented;
            rentalInDb.DateReturned = rental.DateReturned;
            rentalInDb.CarId = rental.CarId;
            rentalInDb.CustomerId = rental.CustomerId;

            _context.SaveChanges();      
        }

        public void DeleteSingleRental(RentalDto rental)
        {
            var rentalForDeletion = _context.Rentals.Find(rental.Id);

            _context.Rentals.Remove(rentalForDeletion);

            _context.SaveChanges();
        }
    }
}
