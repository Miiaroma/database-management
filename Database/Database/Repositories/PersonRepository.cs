using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Database.Model;
using System.Data.SqlClient;


namespace Database.Repositories
{
    class PersonRepository : IPersonrepository
    {
        private readonly PersontestdbContext _persontestdbContext = new PersontestdbContext();

        public void Create(Person person)
        {
            //with SQL
            //string sql = $"INSERT INTO PERSON (FirstName, LastName, City, ShoeSize) " +
            //    $"VALUES ({person.FirstName}, {person.LastName}, {person.City}, {person.ShoeSize})";

            //with Entity framework
            _persontestdbContext.Add(person);
            _persontestdbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            //DELETE * FROM PERSON WHERE ID={id}
            var deletedPerson = ReadById(id);
            if (deletedPerson != null)
            {
                _persontestdbContext.Person.Remove(deletedPerson);
                _persontestdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tiedon poisto ei onnistunut, ID tuntematon");
            }            
        }

        public List<Person> ReadByCity(string city)
        {
            //Listing the data by calling the connection
            //var persons = _persontestdbContext.Person.ToListAsync().Result;
            //return persons;

            //var persons = _persontestdbContext.Person.
            //    FromSql($"SELECT * FROM PERSON WHERE CITY = {city}").
            //    ToList();

            //By Lambda
            var persons = _persontestdbContext.
                Person.
                Where(p => p.City == city).
                ToListAsync().
                Result;
            return persons;
        }

        public Person ReadById(long id)
        {
            // Alt A. SQL
            //var person = _persontestdbContext.
            //    Person.
            //    FromSql($"SELECT * FROM PERSON WHERE ID = {id}").
            //    FirstOrDefault();

            // Alt B. Lambda
            //var person = _persontestdbContext.
            //    Person.
            //    FirstOrDefault(p => p.Id == id);

            //Alt C. Entity framework
            var person = _persontestdbContext.Person.Find(id);
            return person;
        }

        public void Update(long id, Person person)
        {
            throw new NotImplementedException();
        }

    }
}
