using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    interface IBankRepository
    {
        //CRUD
        void Create(Bank bank);
        List<Bank> GetBanks();
        //List<Bank> GetBankCustomers();
        List<Bank> GetTransactionsFromBankCustomersAccounts();
        //void CreateBankCustomerAccount();
        Bank ReadById(long id);

        void Update(long id, Bank bank);
        void DeleteBank(long id);
    }
}
