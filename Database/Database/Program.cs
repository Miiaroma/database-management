using System;
using System.Runtime.InteropServices;
using Database.Repositories;
using Database.Model;
using Database.Views;


namespace Database
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        static void Main(string[] args)
        {
            string choise = null;
            UIModel uiModel = new UIModel();
            string msg = "";

           
            do
            {
                choise = UserInterface();

                switch (choise.ToUpper())
                {
                    case "C":
                        uiModel.CreatePerson();

                        msg = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;
                    case "R":
                        uiModel.ReadById(5001);
                        msg = "\n--------------------------------------\nPaina Enter jatkaaksesi!";
                        break;
                    case "U":
                        uiModel.UpdatePerson();
                        msg = "\n--------------------------------------\nPaina Enter jatkaaksesi!";
                        break;
                    case "D":
                        uiModel.DeletePerson(5003);
                        msg = "\n--------------------------------------\nPaina Enter jatkaaksesi!";
                        break;
                    case "R1":
                        uiModel.ReadByCity();
                        msg = "\n--------------------------------------\nPaina Enter jatkaaksesi!";
                        break;
                    case "X":
                        msg = "\nOhjelman suoritus päättyy!";
                        break;
                    default:
                        msg = "Nyt tuli huti yritä uudestaan - Paina Enter ja aloita alusta!";
                        break;
                }

                Console.WriteLine(msg);
                Console.ReadLine();
                Console.Clear();
            }
            while (choise.ToUpper() != "X");
        }



        static string UserInterface()
        {
            Console.WriteLine("Tietokannan käsittely esimerkki!");
            Console.WriteLine("[C] Lisää tietokantaan uusi tietue");
            Console.WriteLine("[R] Lue tietokannasta tietoja");
            Console.WriteLine("[U] Päivitä henkilön tiedot");
            Console.WriteLine("[D] Poista henkilö tietokannasta");
            Console.WriteLine("[R1] Hae tiedot kaupungista");            
            Console.WriteLine("[X] Lopeta ohjelmansuoritus");
            Console.WriteLine();
            Console.Write("Valitse mitä tehdään: ");

            return Console.ReadLine();
        }

                                 

    }
}