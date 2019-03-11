using System;
using System.Runtime.InteropServices;
using Database.Repositories;
using Database.Model;


namespace Database
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        static void Main(string[] args)
        {
            //Testing database
            CreatePerson();
            var persons = _personRepository.ReadByCity("London");
            //ReadByCity();
            //for (int i = 0; i < 100; i++)
            //{
            //    ReadById(i);
            //}
        }

        static void CreatePerson()
        {
            Person person = new Person();
            person.FirstName = "James";
            person.LastName = "Bond";
            person.City = "London";
            person.ShoeSize = 42;
            _personRepository.Create(person);
                       
        }

        static void ReadByCity()
        {
            var persons = _personRepository.ReadByCity("London");
            
            foreach(var p in persons)
            {
                Console.WriteLine($"{p.ID} {p.FirstName} {p.City}");                
            }
            Console.WriteLine("-----------------------------------------");
        }

        static void ReadById(long Id)
        {
            var person = _personRepository.ReadById(Id);

            if (person == null)
                Console.WriteLine($"Asiakasta numerolla {Id} ei löytynyt!");
            else
                 Console.WriteLine($"{person.ID} {person.FirstName} {person.LastName} {person.City}");
        }                        
    }
}