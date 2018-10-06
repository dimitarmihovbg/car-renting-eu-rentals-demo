using AutoMapper;
using CarRentingEu.Models;
using CarRentingEu.Repository.Interfaces;
using CarRentingEu.Services.Interfaces;
using CarRentingEu.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerForServicing;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository customer, IMapper mapper)
        {
            customerForServicing = customer;
            this.mapper = mapper;
        }

        //CREATE

        public void SaveSingleCustomer(CustomerDto customerToBeSaved)
        {
            var mappedDtoCustomer = mapper.Map<CustomerDto, Customer>(customerToBeSaved);
            customerForServicing.SaveSingleToDb(mappedDtoCustomer);
        }

        //READ

        public CustomerDto GetSingleCustomer(int id)
        {
            var customer = customerForServicing.GetSingleFromDb(id);
            var mappedDtoCustomer = mapper.Map<Customer, CustomerDto>(customer);
            return mappedDtoCustomer;
        }

        public IList<CustomerDto> GetAllCustomers()
        {
            var allCustomers = customerForServicing.GetAllFromDb();
            var mappedDtoCustomers = mapper.Map<List<CustomerDto>>(allCustomers);
            return mappedDtoCustomers;
        }              

        public IList<MembershipTypeDto> GetAllMemberships()
        {
            var allMemberships = customerForServicing.GetAllMembershipsFromDb();
            var mappedDtoMembershipTypes = mapper.Map<List<MembershipTypeDto>>(allMemberships);
            return mappedDtoMembershipTypes;
        }

        //UPDATE

        public void UpdateSingleCustomer(CustomerDto customer)
        {
            var mappedCustomerFromDto = mapper.Map<CustomerDto, Customer>(customer);
            customerForServicing.UpdateSingleFromDb(mappedCustomerFromDto);
        }

        //DELETE

        public void DeleteSingleCustomer(CustomerDto customer)
        {
            var mappedCustomerFromDto = mapper.Map<CustomerDto, Customer>(customer);
            customerForServicing.DeleteSingleFromDb(mappedCustomerFromDto);
        }
    }
}
