using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonDB.Models;

namespace PersonDB.Repositories
{
    class PhoneRepository
    {
        public void Create(Phone phone)
        {
            using (var context = new PersondbContext())
            {
                try
                {
                    context.Add(phone);
                    context.SaveChanges();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message + ex.LineNumber);
                }
            }
        }

        public List<Phone> GetPhone()
        {
            using (var context = new PersondbContext())
            {
                List<Phone> phones = context.Phone.ToListAsync().Result;
                return phones;
            }
        }

        public Phone GetPhoneById(int id)
        {
            using (var context = new PersondbContext())
            {

                var phone = context.Phone.Find(id);

                return phone;
            }
        }
    }
}
