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

        public void PrintToScreen(List<Person> persons)
        {
            Console.WriteLine("Id, Nimi, Ikä\n" +
                              "-------------------\n");

            foreach (var p in persons)
            {
                Console.WriteLine(p.ShowData());
            }
        }

        public void PrintToScreen(Person person)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");

            if (person.Phone.Count == 0)
                Console.WriteLine("Puhelinta ei löydy");
            else
                Console.WriteLine("Id\tTyyppi\t\tNumero");
            foreach (var pPhone in person.Phone)
            {
                Console.WriteLine($"{pPhone.ToString()}");
            }
            Console.WriteLine("\n-------------\n");
        }

        public void AddPerson()
        {
            Console.Write("Syötä nimi: ");
            string name = Console.ReadLine();
            Console.Write("Syötä ikä: ");
            short age = short.Parse(Console.ReadLine());

            List<Phone> phones = new List<Phone>();
            string addAnother = "K";
            Console.WriteLine("Lisätään puhelinnumerot");
            do
            {
                Console.Write("Syötä puhelinnumero: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Puhelimen tyyppi Home tai Work: ");
                string phoneType = Console.ReadLine();

                var addPhone = new Phone(phoneType, phoneNumber);
                phones.Add(addPhone);

                Console.Write("Lisätäänkö toinen puhelinumero K tai E: ");
                addAnother = Console.ReadLine();

            } while (addAnother.ToUpper() != "E");

            var addPerson = new Person(name, age, phones);
            PersonRepository personRepository = new PersonRepository();
            personRepository.Create(addPerson);
        }

        //public void CreatePerson()
        //{
        //    Person newPerson = new Person();
        //    newPerson.Name = "Hessu Hopo";
        //    newPerson.Age = 40;
            //newPerson.Phone = new List<Phone>
            //{
            //    new Phone{Type = "Home", Number = "1144556"},
            //    new Phone{Type = "Work", Number = "01021123"}
            //};
        //    _personRepository.Create(newPerson);
        //}

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
                Console.WriteLine($"Henkilöä numerolla {Id} ei löytynyt!");
            }
            else
                Console.WriteLine($"\n{person.Id} {person.Name} {person.Age}");
        }

        public void UpdatePerson()
        {
            Person updatePerson = _personRepository.ReadById(11);
            updatePerson.Name = "Pikku Apulainen";
            updatePerson.Age = 28;
            //updatePerson.Phone = new List<Phone>
            //{
            //    new Phone{Type = "Home", Number = "1122334"},
            //    new Phone{Type = "Work", Number = "22334455"}
            //};

            _personRepository.Update(17, updatePerson);
        }

        public void DeletePerson(int id)
        {
            ReadById(id);
            _personRepository.Delete(id);            
        }
    }
}





















