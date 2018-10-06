using CarRentingEu.Models;
using CarRentingEu.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CarRentingEu.Repository 
{
   public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext _context;

        public CustomerRepository()
        {
            _context = new ApplicationDbContext();
        }

        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //CREATE

        public void SaveSingleToDb(Customer customerToBeSaved)
        {
            _context.Customers.Add(customerToBeSaved);

            _context.SaveChanges();
        }        

        //READ

        public Customer GetSingleFromDb(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            return customer;
        }

        public IList<Customer> GetAllFromDb()
        {
            var customers = _context.Customers.Include(m => m.MembershipType).ToList();
            return customers;
        }

        public IList<MembershipType> GetAllMembershipsFromDb()
        {
            var memberships = _context.MembershipTypes.ToList();
            return memberships;
        }

        //UPDATE

        public void UpdateSingleFromDb(Customer customer)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;        

            _context.SaveChanges();
        }

        //DELETE

        public void DeleteSingleFromDb(Customer customer)
        {
            Customer customerForDeletion = _context.Customers.Find(customer.Id);
            _context.Customers.Remove(customerForDeletion);

            _context.SaveChanges();
        }
    }
}
