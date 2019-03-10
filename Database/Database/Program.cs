using System;
using Database.Repositories;
using Database.Model;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing database Read
            PersonRepository personRepository = new PersonRepository();
            var persons = personRepository.Read();

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.ID} {p.FirstName} {p.LastName}");
            }
            Console.WriteLine();

            var person = personRepository.ReadById(1);
            Console.WriteLine($"{person.ID} {person.FirstName} {person.LastName}");

            Console.ReadLine();
        }
    }
}
