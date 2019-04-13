using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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

        public Transaction GetTransactionById(int id)
        {
            var transaction = _bankappContext.Transaction.Find(id);
            return transaction;

        }
    }
}
