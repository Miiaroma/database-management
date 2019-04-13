using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    interface IAccountRepository
    {
        List<Account> Read();
        Account GetAccountByIban(string iban);
        void CreateAccount(Account account);
        void DeleteAccount(string iban);
        void CreateTransaction(Transaction transaction);
    }
}
