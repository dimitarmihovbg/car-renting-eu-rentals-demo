using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Configuration
{
    public class MappingConfiguration
    {
        private IServiceCollection services;

        public MappingConfiguration(IServiceCollection services)
        {
            this.services = services;
        }        

        public void RegisterMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }
            );

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
