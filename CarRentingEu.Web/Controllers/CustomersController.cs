using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentingEu.Models;
using CarRentingEu.Services.Interfaces;
using CarRentingEu.Web.ViewModels;
using CarRentingEu.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CarRentingEu.Repository;

namespace CarRentingEu.Web.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerService customer;

        public CustomersController(ICustomerService customer)
        {
            this.customer = customer;
        }

        public ViewResult Index()
        {
            var result = customer.GetAllCustomers();
            return View(result);
        }

        public ViewResult New()
        {
            var membershipTypes = customer.GetAllMemberships();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("NewCustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var chooseCustomerForUpdate = customer.GetSingleCustomer(id);
            var membershipTypes = customer.GetAllMemberships();


            if (chooseCustomerForUpdate == null)
            {
                return View("CustomerNotFound");
            }

            var viewModel = new CustomerFormViewModel(chooseCustomerForUpdate)
            {
                MembershipTypes = customer.GetAllMemberships()
            };

            return View("EditCustomerForm", viewModel);
        }      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerDto customerToBeSaved)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = customer.GetAllMemberships()
                };

                return View("NewCustomerForm", viewModel);
            }

            customer.SaveSingleCustomer(customerToBeSaved);

            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CustomerDto customerToBeSaved)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = customer.GetAllMemberships()
                };

                return View("EditCustomerForm", viewModel);
            }

            customer.UpdateSingleCustomer(customerToBeSaved);

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Delete(int id)
        {
            var customerInDb = customer.GetSingleCustomer(id);

            if (customerInDb == null)
            {
                return NotFound();
            }               

            customer.DeleteSingleCustomer(customerInDb);
            return RedirectToAction("Index", "Customers");
        }
    }
}