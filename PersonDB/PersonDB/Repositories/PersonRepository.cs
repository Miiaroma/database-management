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
            var deletedPerson = ReadById(id);

            if (deletedPerson != null)
            {
                _persondbContext.Person.Remove(deletedPerson);
                _persondbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }

            else
            {
                Console.WriteLine("Tiedon poisto ei onnistunut, ID tuntematon.");
            }
        }

        public List<Person> Read()
        {
            var persons = _persondbContext.Person
                //.Include(p => p.Phone)
                .ToListAsync().
                Result;
            return persons;
        }

        public Person ReadById(long id)
        {
            var person = _persondbContext.Person.Find(id);
            return person;
        }

        public void Update(long id, Person person)
        {
            var isPerson = ReadById(id);
            if (isPerson != null)
            {
                _persondbContext.Update(person);
                _persondbContext.SaveChanges();

                Console.WriteLine("Tiedot tallennetty onnistuneesti!");
            }

            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui, henkilöä ei ole olemassa!");
            }
        }

        public List<Person> GetPersonPhone()
        {
            List<Person> persons = _persondbContext.Person
                .Include(p => p.Phone)
                .ToListAsync().Result;
            return persons;
        }

        public Person GetPersonByIdAndPhones(int id)
        {
            var person = _persondbContext.Person
                .Include(p => p.Phone)
                .Single(p => p.Id == id);

            return person;
        }

    }
}

