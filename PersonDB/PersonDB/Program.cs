using System;
using PersonDB.Repositories;
using PersonDB.Models;
using System.Collections.Generic;
using PersonDB.Views;

namespace PersonDB
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            string message = string.Empty;
            UIModel uiModel = new UIModel();
            
            do
            {
                cki = UserInterface();
                switch (cki.Key)
                {
                    case ConsoleKey.C:
                        //uiModel.CreatePerson();
                        uiModel.AddPerson();
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.R:
                        //uiModel.Read();
                        uiModel.PrintToScreen(_personRepository.Read());
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.U:
                        uiModel.UpdatePerson();
                        message = "\n-----------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D:
                        uiModel.DeletePerson(18);
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.I:
                        //uiModel.ReadById(1);
                        Console.Write("\nSyötä henkilön id, jonka tiedot näytetään: ");
                        int id = int.Parse(Console.ReadLine());
                        uiModel.PrintToScreen(_personRepository.GetPersonByIdAndPhones(id));                        
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.P:
                        Console.Write("\nSyötä henkilön id, jonka tiedot näytetään: \n");
                        id = int.Parse(Console.ReadLine());
                        Person updatePersonAndPhone = _personRepository.GetPersonByIdAndPhones(id);
                        uiModel.PrintToScreen(_personRepository.GetPersonByIdAndPhones(id));
                        Console.Write("Valitse id, jonka haluat muuttaa: ");
                        int pId = int.Parse(Console.ReadLine());

                        Console.Write("Syötä uusi numero: ");
                        string newNumber = Console.ReadLine();
                        foreach (var p in updatePersonAndPhone.Phone)
                        {
                            if (p.Id == pId)
                                p.Number = newNumber;
                        }
                        _personRepository.Update(2, updatePersonAndPhone);                        
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.Escape:
                        message = "\nOhjelman suoritus päättyy.";
                        break;

                    default:
                        message = "Virhe - Paina Enter ja aloita alusta!";
                        break;
                }
                Console.WriteLine(message);
                Console.ReadLine();
                Console.Clear();
            } while (cki.Key != ConsoleKey.Escape);

            Console.WriteLine("Ohjelman suoritus päättyi!");
        }

        static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("Tietokannan käsittely");
            Console.WriteLine("[C] Lisää tietokantaan uusi tietue.");
            Console.WriteLine("[R] Lue tietokannasta tietoja.");
            Console.WriteLine("[U] Päivitä henkilön tiedot.");
            Console.WriteLine("[D] Poista henkilö tietokannasta.");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("[I] Hae tiedot tunnuksen mukaan.");
            Console.WriteLine("[P] Päivitä puhelinumerot.");
            Console.WriteLine("[ESC] Lopeta ohjelman suoritus.");
            Console.WriteLine();
            Console.WriteLine("Valitse vaihtoehto:");

            return Console.ReadKey();
        }

    }
}

