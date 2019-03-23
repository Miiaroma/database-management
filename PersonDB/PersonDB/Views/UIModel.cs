using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;
using PersonDB.Repositories;

namespace PersonDB.Views
{
    class UIModel
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        public void CreatePerson()
        {
            Person newPerson = new Person();            
            newPerson.Name = "Hessu Hopo";
            newPerson.Age = 40;
            newPerson.Phone = new List<Phone>
            {
                new Phone{Type = "Home", Number = "1144556"},
                new Phone{Type = "Work", Number = "01021123"}
            };            
            _personRepository.Create(newPerson);
        }

        public void Read()
        {
            var persons = _personRepository.Read();

            foreach (var p in persons)
            {
                Console.WriteLine($"\n{p.Id} {p.Name} {p.Age}");
            }
            Console.WriteLine("-----------------------------------------");
        }

        public void ReadById(long Id)
        {
            var person = _personRepository.ReadById(Id);

            if (person == null)
            {
                Console.WriteLine($"Henkilöä numerolla {person.Id} ei löytynyt!");
            }
            else
                Console.WriteLine($"\n{person.Id} {person.Name} {person.Age}");
        }

        public void UpdatePerson()
        {
            Person updatePerson = _personRepository.ReadById(11);
            updatePerson.Name = "Pikku Apulainen";
            updatePerson.Age = 26;
            updatePerson.Phone = new List<Phone>
            {
                new Phone{Type = "Home", Number = "1122334"},
                new Phone{Type = "Work", Number = "22334455"}
            };

            _personRepository.Update(11, updatePerson);
        }

        public void DeletePerson(long id)
        {
            ReadById(id);
            _personRepository.Delete(id);
            ReadById(id);
        }                    
    }
}
     



















       
