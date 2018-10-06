using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Repository.Interfaces
{
    public interface ICustomerRepository 
    {
        //CREATE

        void SaveSingleToDb(Customer customerToBeSaved);

        //READ

        Customer GetSingleFromDb(int id);

        IList<Customer> GetAllFromDb();

        IList<MembershipType> GetAllMembershipsFromDb();

        //UPDATE

        void UpdateSingleFromDb(Customer customer);

        //DELETE

        void DeleteSingleFromDb(Customer customer);
    }
}
