﻿using AutoMapper;
using CarRentingEu.Dtos;
using CarRentingEu.Models;
using CarRentingEu.Repository.Interfaces;
using CarRentingEu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRentingEu.Services
{
    public class RentalService : IRentalService
    {
        private IRentalRepository rentalForServicing;
        private readonly IMapper mapper;

        public RentalService(IRentalRepository rental, IMapper mapper)
        {
            rentalForServicing = rental;
            this.mapper = mapper;
        }

        //CREATE

        public void SaveSingleRental(RentalDto rental)
        {
            var mappedRentalFromDto = mapper.Map<RentalDto, Rental>(rental);
            rentalForServicing.SaveSingleToDb(mappedRentalFromDto);
        }

        //READ


        public IList<RentalDto> GetAllRentals()
        {
            var allRentals = rentalForServicing.GetAllFromDb();
            var mappedDtoRentals = mapper.Map<List<RentalDto>>(allRentals);
            return mappedDtoRentals;
        }

        public RentalDto GetSingleRental(int id)
        {           
            var rental = rentalForServicing.GetSingleFromDb(id);
            var mappedDtoFromCustomer = mapper.Map<Rental, RentalDto>(rental);
            return mappedDtoFromCustomer;
        }

        //UPDATE

        public void UpdateSingleRental(RentalDto rental)
        {
            var mappedRentalFromDto = mapper.Map<RentalDto, Rental>(rental);
            rentalForServicing.UpdateSingleFromDb(mappedRentalFromDto);
        }

        //DELETE

        public void DeleteSingleRental(RentalDto rental)
        {
            var mappedRentalFromDto = mapper.Map<RentalDto, Rental>(rental);
            rentalForServicing.DeleteSingleFromDb(mappedRentalFromDto);
        }
    }
}
