using System;
using System.Collections.Generic;
using System.Text;using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Views
{
    class AccountView
    {
        private static readonly AccountRepository _accountRepository = new AccountRepository();
        private static readonly TransactionRepository _transactionRepository = new TransactionRepository();

        public void CreateAccount()
        {
            Account account = new Account();
            account.Iban = "FI123 12345";
            account.Name = "Talletusili";
            account.BankID = 2;
            account.CustomerID = 4;
            account.Balance = 20000;

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
                Console.WriteLine($"\n{account.Iban},{account.CustomerID}");
        }

        public void DeleteAccount(string iban)
        {
            _accountRepository.GetAccountByIban(iban);
            _accountRepository.DeleteAccount(iban);
        }
        static void CreateTransaction()
        {
            Transaction transaction = new Transaction
            {
                Iban = "FI49123456789",
                Amount = -3000,
                TimeStamp = DateTime.Today                
            };
            _accountRepository.CreateTransaction(transaction);
        }
        static void GetTransactionById()
        {            
            _transactionRepository.GetTransactionById(4);
        }
    }
}
