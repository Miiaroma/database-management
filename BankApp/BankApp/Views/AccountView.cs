using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Views
{
    class AccountView
    {
        private static readonly AccountRepository _accountRepository = new AccountRepository();
        private static readonly TransactionRepository _transactionRepository = new TransactionRepository();
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();
        private static readonly BankRepository _bankRepository = new BankRepository();

        public void CreateAccount()
        {
            Account account = new Account();
            account.Iban = "FI432112345";
            account.Name = "Säästötili";
            account.BankId = 2;
            account.CustomerId = 15;
            account.Balance = 1500;

            _accountRepository.CreateAccount(account);
        }

        public void ReadbyIban(string iban)
        {
            var account = _accountRepository.GetAccountByIban(iban);

            if (account == null)
            {
                Console.WriteLine($"Tiliä {account.Iban} ei löytynyt!");
            }
            else
                Console.WriteLine($"\nIban: {account.Iban}\nPankki id: {account.BankId}\nTilin nimi: {account.Name} " +
                    $"\nAsiakas nro: {account.CustomerId}\nSaldo: {account.Balance} €");
        }

        public void DeleteAccount(string iban)
        {
            _accountRepository.GetAccountByIban(iban);
            _accountRepository.DeleteAccount(iban);
        }

        public void ReadbyId(long id)
        {
            var customers = _customerRepository.GetCustomerById(id);
            var account = _accountRepository.Read(id);
           
            foreach (var a in account)
            {
                if (account == null)
                {
                    Console.WriteLine($"Tiliä {a.Iban} ei löytynyt!");
                }
                else
                    Console.WriteLine($"\nAsiakas/id: {a.CustomerId}\nTilinro: {a.Iban}\nTyyppi: {a.Name}\nSaldo: {a.Balance} €");
            }
        }
        
        public void CreateTransaction()
        {
            Transaction transaction = new Transaction
            {
                Iban = "FI234598761",
                Amount = 500,
                TimeStamp = DateTime.Today                
            };
            _accountRepository.CreateTransaction(transaction);
        }

        public void GetTransactionByIban(string iban)
        {            
           var transactions = _transactionRepository.GetTransactionByIban(iban);
            Console.WriteLine($"\nTilin: {iban} tapahtumat");

            foreach (var t in transactions)
            {
                Console.WriteLine($"{t.Amount} \t{t.TimeStamp}");
            }
        }

        public void PrintAll()
        {
            BankRepository bankRepository = new BankRepository();

            var bankCustomers = bankRepository.GetTransactionsFromBankCustomersAccounts();

            foreach (var bC in bankCustomers)
            {
                Console.WriteLine(bC.ToString());
                foreach (var c in bC.Customer)
                {
                    Console.WriteLine(c.ToString());
                    foreach (var cAccount in c.Account)
                    {
                        Console.WriteLine($"{cAccount.ToString()}");
                        foreach (var t in cAccount.Transaction)
                        {
                            Console.WriteLine($"{t.ToString()}");
                        }
                    }
                }
            }
        }
    }
}
