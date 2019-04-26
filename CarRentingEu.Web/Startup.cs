using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarRentingEu.Web.Data;
using CarRentingEu.Web.Models;
using CarRentingEu.Web.Services;
using CarRentingEu.Services.Interfaces;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using CarRentingEu.Models;
using CarRentingEu.Configuration;

namespace CarRentingEu.Web
{
    public class Startup
    {
        public Startup()
        {
        }
        //  This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {                   
            // Add application services
            services.AddMvc();
            services.AddTransient<IEmailSender, EmailSender>();

            //Register Repository From Configuration ClassLibrary
            var repositoryConfig = new RepositoryConfiguration(services);
            repositoryConfig.RegisterRepository();


            //Register Services From Configuration ClassLibrary
            ServiceConfiguration serviceConfig = new ServiceConfiguration(services);
            services.AddSingleton(serviceConfig.RegisterCarService());
            services.AddSingleton(serviceConfig.RegisterRentalsService());
            services.AddSingleton(serviceConfig.RegisterCustomerService());

            //Register Mapping From Configuration ClassLibrary
            var mappingConfig = new MappingConfiguration(services);
            mappingConfig.RegisterMapper();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
