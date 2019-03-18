using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonDB.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace PersonDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
     private readonly PersondbContext _persondbContext = new PersondbContext();

        public void Create(Person person)
        {
            _persondbContext.Person.Add(person);
            _persondbContext.SaveChanges();          
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            var persons = _persondbContext.Person
                .Include(p=>p.Phone)
                .ToList();
            return persons;            
        }

        public Person Read(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(long id, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
