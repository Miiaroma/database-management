using System;
using PersonDB.Repositories;
using PersonDB.Models;
using System.Collections.Generic;

namespace PersonDB
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository personRepository = new PersonRepository();

            Person newPerson = new Person();
            newPerson.Name = "Pöllö Peloton";
            newPerson.Age = 60;
            newPerson.Phone = new List<Phone>
            {
                new Phone{Type="HOME", Number = "ÖÖÖÖÖ" },
                new Phone{Type = "WORK", Number = "010101"}
            };
                  
            personRepository.Create(newPerson);
            personRepository.Read();

        }
    }
}
