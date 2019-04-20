using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;



namespace BankApp.Repositories
{
    class BankRepository : IBankRepository
    {
        private readonly BankappContext _bankappContext = new BankappContext();

        public void Create(Bank bank)
        {
            _bankappContext.Bank.Add(bank);
            _bankappContext.SaveChanges();
        }

        public List<Bank> GetBanks()
        {
            List<Bank> banks = _bankappContext.Bank.ToListAsync().Result;
            return banks;
        }

        public List<Bank> GetBankCustomers()
        {
            var banks = _bankappContext.Bank
                .Include(b => b.Customer)
                .ToListAsync().
                Result;
            return banks;
        }

        public Bank ReadById(long id)
        {
            var banks = _bankappContext.Bank.Find(id);
            return banks;
        }

        public void Update(long id, Bank bank)
        {
        var isBank = ReadById(id);
        if (isBank != null)
        {
            _bankappContext.Update(bank);
            _bankappContext.SaveChanges();

            Console.WriteLine("Tiedot tallennetty onnistuneesti!");
        }

        else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui, pankkia ei ole olemassa!");
            }
        }

        public void DeleteBank(long id)
        {
            var deletedBank = ReadById(id);

            if (deletedBank != null)
            {
                _bankappContext.Bank.Remove(deletedBank);
                _bankappContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }

            else
            {
                Console.WriteLine("Tiedon poisto ei onnistunut, ID tuntematon.");
            }
        }
                
        public List<Bank> GetTransactionsFromBankCustomersAccounts()
        {
            List<Bank> banks = _bankappContext.Bank
                .Include(b => b.Customer)
                .Include(b => b.Account)
                .Include(b => b.Account).ThenInclude(a => a.Transaction)
                .ToListAsync().Result;
            return banks;
        }
    }
}
