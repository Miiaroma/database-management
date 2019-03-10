using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Database.Model;

namespace Database.Repositories
{
    class PersonRepository : IPersonrepository
    {
        private readonly PersontestdbContext _persontestdbContext = new PersontestdbContext();

        public void Create(Person person)
        {

            throw new NotImplementedException();
        }

        public void Delete(long id)
        {

            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            var persons = _persontestdbContext.Person.ToListAsync().Result;
            return persons;
        }

        public Person ReadById(long id)
        {
            var person = _persontestdbContext.Person.Find(id);
            return person;
        }

        public void Update(long id, Person person)
        {
            throw new NotImplementedException();
        }

    }
}
