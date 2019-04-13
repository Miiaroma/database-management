using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    interface ICustomerRepository
    {
        List<Customer> Read();
        Customer GetCustomerById(long id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer, long id);
        void DeleteCustomer(long id);
    }
}
