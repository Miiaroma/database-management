using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 
using BankApp.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly BankappContext _bankappContext = new BankappContext();

        public void CreateAccount(Account account)
        {
            _bankappContext.Account.Add(account);
            _bankappContext.SaveChanges();            
        }

        public void CreateTransaction(Transaction transaction)
        {
            try
            {
                _bankappContext.Transaction.Add(transaction);
                
                var account = GetAccountByIban(transaction.Iban);
                account.Balance += transaction.Amount;

                _bankappContext.Account.Update(account);
                _bankappContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Account> Read()
        {
            var accounts = _bankappContext.Account
                .ToListAsync().
                Result;
            return accounts;
           
        }

        public Account GetAccountByIban(string iban)
        {
            var account = _bankappContext.Account.Find(iban);
            //var account = _bankappContext.Account.FirstOrDefault(a => a.Iban == iban);
            return account;
        }

        public void DeleteAccount(string iban)
        {
            var deletedAccount = GetAccountByIban(iban);

            if (deletedAccount != null)
            {
                _bankappContext.Account.Remove(deletedAccount);
                _bankappContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }

            else
            {
                Console.WriteLine("Tiedon poisto ei onnistunut, IBAN tuntematon.");
            }
        }

    }
}
