using CarRentingEu.Models;
using CarRentingEu.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Services.Interfaces
{
    public interface ICustomerService
    {
        //CREATE

        void SaveSingleCustomer(CustomerDto customerToBeSaved);

        //READ

        CustomerDto GetSingleCustomer(int id);

        IList<CustomerDto> GetAllCustomers();        

        IList<MembershipTypeDto> GetAllMemberships();

        //UPDATE

        void UpdateSingleCustomer(CustomerDto customer);

        //DELETE

        void DeleteSingleCustomer(CustomerDto customer);
       
    }
}
