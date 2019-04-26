using CarRentingEu.Models;
using CarRentingEu.Services;
using CarRentingEu.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Configuration
{
    public class ServiceConfiguration
    {
        private IServiceCollection services { get; }

        public ServiceConfiguration(IServiceCollection services)
        {
            this.services = services;
        }

        public IServiceCollection RegisterCarService()
        {
            return services.AddTransient<ICarService, CarService>();           
        }

        public IServiceCollection RegisterCustomerService()
        {
            return services.AddTransient<ICustomerService, CustomerService>();
        }

        public IServiceCollection RegisterProviderService()
        {
            return services.AddTransient<IProviderServices, ProviderService>();
        }

        public IServiceCollection RegisterRentalsService()
        {
            return services.AddTransient<IRentalService, RentalService>();
        }
    }
}
