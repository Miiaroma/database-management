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
            account.BankId = 2;
            account.CustomerId = 4;
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
                Console.WriteLine($"\nIban: {account.Iban}\nPankki id: {account.BankId}\nTilin nimi: {account.Name} " +
                    $"\nAsiakas nro: {account.CustomerId}\nSaldo: {account.Balance} €");
        }

        public void DeleteAccount(string iban)
        {
            _accountRepository.GetAccountByIban(iban);
            _accountRepository.DeleteAccount(iban);
        }

        public void CreateTransaction()
        {
            Transaction transaction = new Transaction
            {
                Iban = "FI234598761",
                Amount = 1000,
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
    }
}
