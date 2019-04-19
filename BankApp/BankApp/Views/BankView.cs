using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;


namespace BankApp.Views
{  
    class BankView
    {
        private static readonly BankRepository _bankRepository = new BankRepository();
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();
        private static readonly AccountRepository _accountRepository = new AccountRepository();

        public void CreateBank()
        {
            Bank bank = new Bank();
            bank.Name = "Bigbank";
            bank.Bic = "BIGKFIH1";

            _bankRepository.Create(bank);
        }

        static private void Read()
        {
            var banks = _bankRepository.GetBanks();

            foreach (var p in banks)
            {
                Console.WriteLine($"\n{p.Id},{p.Name},{p.Bic}");
            }
            Console.WriteLine();
        }
        
        public void ReadById(long Id)
        {
            var bank = _bankRepository.ReadById(Id);

            if (bank == null)
            {
                Console.WriteLine($"Pankkia {Id} ei löytynyt!");
            }
            else
                Console.WriteLine($"\n{bank.Id} {bank.Name} {bank.Bic}");
        }

        public void UpdateBank()
        {
            Bank updateBank = _bankRepository.ReadById(6);
            updateBank.Name = "Sbank";
            updateBank.Bic = "SBANFIHH";            
            _bankRepository.Update(6, updateBank);
        }

        public void DeleteBank(int id)
        {
            ReadById(id);
            _bankRepository.DeleteBank(id);
        }

        public void PrintAccounts(List<Account> list)
        {
            var accounts = _accountRepository.Read();
            foreach (var a in accounts)
            {
                if (a == null)
                {
                    Console.WriteLine("Tiliä ei löytynyt.");
                }

                else
                {
                    Console.WriteLine($"\nTili: {a.Iban}\nNimi: {a.Name}\nPankki/id: {a.BankId}");
                }
            }
        }
                
        public void CreateCustomer()
        {
            Customer customer = new Customer
            {
                Firstname = "Brita",
                Lastname = "Kottarainen",
                BankId = 2,
            };

            _customerRepository.CreateCustomer(customer);
        }
       
        public void ReadCustomerbyId(long id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                Console.WriteLine($"Asiakasta {customer.Id} ei löytynyt!");
            }
            else
                Console.WriteLine($"\n{customer.Id},{customer.Firstname},{customer.Lastname}");
        }        

        public void UpdateCustomer()
        {
            Customer updateCustomer = _customerRepository.GetCustomerById(2);
            updateCustomer.Firstname = "Tiina";
            updateCustomer.Lastname = "Tallettaja";
            updateCustomer.BankId = 1;

            _customerRepository.UpdateCustomer(updateCustomer, 2);
        }
        
        public void DeleteCustomer(int id)
        {
            _customerRepository.GetCustomerById(id);
            _customerRepository.DeleteCustomer(id);
        }

        public void PrintCustomers(List<Customer> list)
        {
            var customers = _customerRepository.Read();
            foreach (var c in customers)
            {
                if (c == null)
                {
                    Console.WriteLine("Tiliä ei löytynyt.");
                }

                else
                {
                    Console.WriteLine($"\n{c.Firstname} {c.Lastname}\nPankki/id:{c.BankId}");
                }
            }
        }   
    }
}


