using CarRentingEu.Models;
using CarRentingEu.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Configuration
{
    public class RepositoryConfiguration
    {
        public RepositoryConfiguration()
        {
        }

        public RepositoryConfiguration(IServiceCollection services)
        {
            this.services = services;
        }

        private IServiceCollection services;

        public void RegisterRepository()
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(ApplicationDbContext.connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
