using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentingEu.Dtos;
using CarRentingEu.Models;
using CarRentingEu.Services.Interfaces;
using CarRentingEu.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingEu.Web.Controllers
{
    public class RentalsController : Controller
    {
        private IRentalService rental;
        private ICustomerService customer;
        private ICarService car;
        private readonly IMapper _mapper;

        public RentalsController(IRentalService rental, ICustomerService customer, ICarService car, IMapper mapper)
        {
            this.rental = rental;
            this.customer = customer;
            this.car = car;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var result = rental.GetAllRentals();
            return View(result);
        }

        public ViewResult New()
        {
            var customers = customer.GetAllCustomers();
            var cars = car.GetAllCars();

            var rentalFormViewModel = new RentalFormViewModel
            {      
                Customers = customers,
                Cars = cars
            };

            return View("NewRentalForm", rentalFormViewModel);
        }

        public ActionResult Edit (int id)
        {
            var chooseRentalForUpdate = rental.GetSingleRental(id);
            var allCars = car.GetAllCars();
            var allCustomers = customer.GetAllCustomers();


            if (chooseRentalForUpdate == null)
            {
                return View("RentalNotFound");
            }

            var viewModel = new RentalFormViewModel(chooseRentalForUpdate)
            {
                Cars = allCars,
                Customers = allCustomers
            };

            return View("EditRentalForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RentalDto rentalToBeSaved)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new RentalFormViewModel(rentalToBeSaved)
                {
                    Customers = customer.GetAllCustomers(),
                    Cars = car.GetAllCars()
                };

                return View("NewCarForm", viewModel);
            }

            rental.SaveSingleRental(rentalToBeSaved);

            return RedirectToAction("Index", "Rentals");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(RentalDto rentalToBeSaved)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new RentalFormViewModel(rentalToBeSaved)
                {
                    Customers = customer.GetAllCustomers(),
                    Cars = car.GetAllCars()
                };

                return View("EditCarForm", viewModel);
            }

            rental.UpdateSingleRental(rentalToBeSaved);

            return RedirectToAction("Index", "Rentals");
        }

        public ActionResult Delete(int id)
        {
            var rentalInDb = rental.GetSingleRental(id);

            if (rentalInDb == null)
            {
                return NotFound();
            }

            rental.DeleteSingleRental(rentalInDb);
            return RedirectToAction("Index", "Rentals");
        }
    }
}