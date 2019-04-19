using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BankApp.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly BankappContext _bankappContext = new BankappContext();

        public void CreateCustomer(Customer customer)
        {
            try
            {
                _bankappContext.Add(customer);
                _bankappContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
            }
        }
                
        public void DeleteCustomer(long id)
        {
            var deletedCustomer = GetCustomerById(id);

            if (deletedCustomer != null)
            {
                _bankappContext.Customer.Remove(deletedCustomer);
                _bankappContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }

            else
            {
                Console.WriteLine("Tiedon poisto ei onnistunut, ID tuntematon.");
            }
        }

        public Customer GetCustomerById(long id)
        {
            var customer = _bankappContext.Customer.FirstOrDefault(c => c.Id == id);                        
            return customer;
        }

        public List<Customer> Read()
        {
            List<Customer> customers = _bankappContext.Customer.ToListAsync().Result;
            return customers;          
        }

        public void UpdateCustomer(Customer customer, long id)
        {
            var isCustomer = GetCustomerById(id);
            if (isCustomer != null)
            {
                _bankappContext.Update(customer);
                _bankappContext.SaveChanges();

                Console.WriteLine("Tiedot tallennetty onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui, asiakasta ei ole olemassa!");
            }            
        }
    }       
}

