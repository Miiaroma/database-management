using System;
using BankApp.Models;
using BankApp.Repositories;
using BankApp.Views;

namespace BankApp
{
    class Program
    {
        private static readonly BankRepository _bankRepository = new BankRepository();
        private static readonly AccountRepository _accountRepository = new AccountRepository();
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();
        private static readonly TransactionRepository _transactionepository = new TransactionRepository();

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            string message = string.Empty;
            BankView bankView = new BankView();
            AccountView accountView = new AccountView();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            do
            {
                cki = UserInterface();
                switch (cki.Key)
                {
                    case ConsoleKey.C:
                        bankView.CreateBank();
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;
                    
                    case ConsoleKey.U:
                        bankView.UpdateBank();
                        message = "\n-----------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D:
                        bankView.DeleteBank(8);
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.A:
                        bankView.CreateCustomer();
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.B:
                        accountView.CreateAccount();
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.E:
                        bankView.PrintAccounts(_accountRepository.Read());
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.F:
                        bankView.PrintCustomers(_customerRepository.Read());
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.G:
                        bankView.UpdateCustomer();
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.H:
                        bankView.DeleteCustomer(14);
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.I:
                        accountView.DeleteAccount("22113344556677");
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.J:                        
                        accountView.ReadbyId(1);
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.K:
                        accountView.CreateTransaction();
                        message = "\n------------------------------------\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.L:
                        accountView.GetTransactionByIban("112233445566778");
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
            Console.WriteLine("Pankkitietokannan käsittely");
            Console.WriteLine("[C] Lisää tietokantaan uusi pankki.");
            Console.WriteLine("[U] Päivitä pankin tiedot.");
            Console.WriteLine("[D] Poista pankki tietokannasta.");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("[A] Lisää pankkiin uusi asiakas.");
            Console.WriteLine("[B] Lisää uudelle asiakkaalle tili.");
            Console.WriteLine("[E] Hae pankissa olevat tilit.");
            Console.WriteLine("[F] Hae pankin asiakkaat.");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("[G] Päivitä asiakastiedot.");
            Console.WriteLine("[H] Poista asiakastiedot.");
            Console.WriteLine("[I] Poista asiakkaan tili.");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("[J] Hae asiakkaan tilit ja niiden saldot.");
            Console.WriteLine("[K] Luo asiakkaalle tilitapahtuma.");
            Console.WriteLine("[L] Hae asiakkaan tilitapahtumat.");

            
            Console.WriteLine("[ESC] Lopeta ohjelman suoritus.");
            Console.WriteLine();
            Console.WriteLine("Valitse vaihtoehto:");

            return Console.ReadKey();
        }
    }
    }
