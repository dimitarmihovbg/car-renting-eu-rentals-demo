using AutoMapper;
using CarRentingEu.Data;
using CarRentingEu.Dtos;
using CarRentingEu.Models;
using CarRentingEu.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarRentingEu.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper mapper;
        private ApplicationDbContext _context;

        public CustomerService(IMapper mapper, ApplicationDbContext _context)
        {
            this._context = _context;
            this.mapper = mapper;
        }

        public void SaveSingleCustomer(CustomerDto customerToBeSaved)
        {
            var mappedDtoCustomer = mapper.Map<CustomerDto, Customer>(customerToBeSaved);

            _context.Customers.Add(mappedDtoCustomer);

            _context.SaveChanges();
        }

        public CustomerDto GetSingleCustomer(int id)
        {
            var customer = _context.Customers.Find(id);

            var mappedDtoCustomer = mapper.Map<Customer, CustomerDto>(customer);

            return mappedDtoCustomer;
        }

        public IList<CustomerDto> GetAllCustomers()
        {
            var customers = _context.Customers.Include(m => m.MembershipType).ToList();

            var mappedDtoCustomers = mapper.Map<List<CustomerDto>>(customers);
           
            return mappedDtoCustomers;
        }              

        public IList<MembershipTypeDto> GetAllMemberships()
        {
            var memberships = _context.MembershipTypes.ToList();

            var mappedDtoMembershipTypes = mapper.Map<List<MembershipTypeDto>>(memberships);         

            return mappedDtoMembershipTypes;
        }

        public void UpdateSingleCustomer(CustomerDto customer)
        {
            var customerInDb = _context.Customers.Find(customer.Id);

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _context.SaveChanges();
        }

        public void DeleteSingleCustomer(CustomerDto customer)
        {
            var customerForDeletion = _context.Customers.Find(customer.Id);

            _context.Customers.Remove(customerForDeletion);

            _context.SaveChanges();         
        }
    }
}
