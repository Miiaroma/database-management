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
                Console.WriteLine($"\n{p.ID},{p.Name},{p.Bic}");
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
                Console.WriteLine($"\n{bank.ID} {bank.Name} {bank.Bic}");
        }

        public void UpdateBank()
        {
            Bank updateBank = _bankRepository.ReadById(6);
            updateBank.Name = "S-pankki";
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
                Console.WriteLine($"\nPankki:{a.BankID}, Iban:{a.Iban}, Nimi:{a.Name}");
            }
        }
                
        public void CreateCustomer()
        {
            Customer customer = new Customer();
            customer.Firstname = "Hannu";
            customer.Lastname = "Hanhi";
            customer.BankID = 2;

            _customerRepository.CreateCustomer(customer);
        }
       
        public void ReadCustomerbyId(long id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                Console.WriteLine($"Asiakasta {customer.ID} ei löytynyt!");
            }
            else
                Console.WriteLine($"\n{customer.ID},{customer.Firstname},{customer.Lastname}");
        }        

        public void UpdateCustomer()
        {
            Customer updateCustomer = _customerRepository.GetCustomerById(1);
            updateCustomer.Firstname = "Sanni";
            updateCustomer.Lastname = "Uusisäästäjä";
            updateCustomer.BankID = 1;

            _customerRepository.UpdateCustomer(updateCustomer, 1);
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
                Console.WriteLine($"\n{c.Firstname}\t{c.Lastname}\tPankki:{c.BankID}");
            }
        }

        //public void CreateBankCustomerAccount()
        //{

        //    Bank bank = new Bank("Swedbank", "SWDFIHH");
        //    Customer customerOne = new Customer("Hannu", "Hanhi");
        //    Customer customerTwo = new Customer("Anni", "Asiakas");

        //    List<Customer> customers = new List<Customer>();
        //    customers.Add(customerOne);
        //    customers.Add(customerTwo);

        //    Account accountOne = new Account("FI123 12345","Käyttötili", 500);
        //    Account accountTwo = new Account("FI123 6789", "Tuottotili", 1000);

        //    List<Account> accounts = new List<Account>();
        //    accounts.Add(accountOne);
        //    accounts.Add(accountTwo);

        //    Transaction transactionOne = new Transaction(300, new DateTime(2019, 04, 10));
        //    Transaction transactionTwo = new Transaction(-100, new DateTime(2019, 04, 10));

        //    List<Transaction> transactions = new List<Transaction>();
        //    transactions.Add(transactionOne);
        //    transactions.Add(transactionTwo);

        //    bank.Customer = customers;
        //    bank.Account = accounts;
        //    accountOne.Transaction = transactions;
        //    customerOne.Customer = customers;

        //    _bankRepository.Create(bank);


        //}

    }
}


