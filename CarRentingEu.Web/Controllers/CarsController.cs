using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentingEu.Dtos;
using CarRentingEu.Models;
using CarRentingEu.Services;
using CarRentingEu.Services.Interfaces;
using CarRentingEu.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingEu.Web.Controllers
{
    public class CarsController : Controller
    {
        private ICarService car;

        public CarsController(ICarService car)
        {
            this.car = car;
        }

        public ViewResult Index()
        {
            var result = car.GetAllCars();
            return View(result);
        }

        public ViewResult New()
        {
            var models = car.GetAllModels();

            var carFormViewModel = new CarFormViewModel
            {
                Models = models
            };

            return View("NewCarForm", carFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            var chooseCarForUpdate = car.GetSingleCar(id);

            //if (chooseCarForUpdate == null)
            //    return HttpNotFound();

            var viewModel = new CarFormViewModel(chooseCarForUpdate)
            {
                Models = car.GetAllModels()
            };

            return View("EditCarForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CarDto carToBeSaved)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CarFormViewModel(carToBeSaved)
                {
                    Models = car.GetAllModels()
                };

                return View("NewCarForm", viewModel);
            }

            car.SaveSingleCar(carToBeSaved);

            return RedirectToAction("Index", "Cars");
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Update(CarDto carToBeSaved)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CarFormViewModel(carToBeSaved)
                {
                    Models = car.GetAllModels()
                };

                return View("EditCarForm", viewModel);
            }

            car.UpdateSingleCar(carToBeSaved);

            return RedirectToAction("Index", "Cars");
        }

        public ActionResult Delete(int id)
        {
            var carInDb = car.GetSingleCar(id);

            if (carInDb == null)
            {
                return NotFound();
            }

            car.DeleteSingleCar(carInDb);
            return RedirectToAction("Index", "Cars");
        }
    }
}