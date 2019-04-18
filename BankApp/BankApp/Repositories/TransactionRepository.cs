using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankApp.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly BankappContext _bankappContext = new BankappContext();

        public List<Transaction> Read()
        {
            List<Transaction> transactions = _bankappContext.Transaction.ToListAsync().Result;
            return transactions;
        }

        public List<Transaction> GetTransactionByIban(string iban)
        {
            var transactions = _bankappContext.Transaction.Where(t => t.Iban==iban).ToList();
            return transactions;
        }
    }
}
