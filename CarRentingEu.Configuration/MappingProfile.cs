using AutoMapper;
using CarRentingEu.Models;
using CarRentingEu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentingEu.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Rental, RentalDto>().ReverseMap();
        }
    }
}
