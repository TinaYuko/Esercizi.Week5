using Esercizio_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    public class Menu
    {
        internal static void Start()
        {
            bool exit = true;
            do
            {
                Console.WriteLine("\nPremi: \n[1] per aggiungere un nuovo conto" +
                    "\n[2] per prelevare" +
                    "\n[3] per versare money" +
                    "\n[4] per visualizzare il saldo" +
                    "\n[5] per chiudere un conto" +
                    "\n[0] per uscire!");

                int choice;
                do
                {
                    Console.WriteLine("Su, forza! Scegli!");
                }
                while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice < 5));

                switch (choice)
                {
                    case 1:
                        AddNewBankAccount();
                        break;
                    case 2:

                        WithDrawMoney();
                        break;
                    case 3:

                        PayIntoAccount();
                        break;
                    case 4:
                        ViewBalance();
                        break;
                    case 5:
                        DeleteAccount();
                        break;

                    case 0:
                       
                        Console.WriteLine("Tutto fatto? Bene, ciao!!!");
                        exit = false;
                        break;
                }
            }
            while (exit);

        }

        private static void DeleteAccount()
        {
            int number;
            do
            {
                Console.WriteLine("Inserisci il numero di conto: ");
            } while (!int.TryParse(Console.ReadLine(), out number));
            BankAccount account = BankManager.GetByAccountNumber(number);

            if (account != null)
            {

                bool isDeleted = BankManager.DeleteAccount(account);
                   
                if (isDeleted)
                {
                    Console.WriteLine("Conto eliminato correttamente.");
                }
                    else
                {
                    Console.WriteLine("Qualcosa è andato storto");
                }
                
            }
            else
            {
                Console.WriteLine("Non esiste un conto con questo numero");
            }
        }

        private static void ViewBalance()
        {

            int number;
            do
            {
                Console.WriteLine("Inserisci il numero di conto: ");
            } while (!int.TryParse(Console.ReadLine(), out number));
            BankAccount account = BankManager.GetByAccountNumber(number);

            if (account != null)
            {
                
                
                Console.WriteLine($"Il saldo del tuo conto: {account.AccountHolderCode} è di {account.Balance}Euro.");
                
            }
            else
            {
                Console.WriteLine("Non esiste un conto con questo numero");
            }
        }

        private static void WithDrawMoney()
        {
            int number;
            do
            {
                Console.WriteLine("Inserisci il numero di conto: ");
            } while (!int.TryParse(Console.ReadLine(), out number));
            BankAccount account = BankManager.GetByAccountNumber(number);

            if (account != null)
            {
                decimal amount = GetAmount("prelevare");
                account.Balance -= amount;
                bool isUpdate = BankManager.UpdateAccount(account);
                if (isUpdate)
                {
                    Console.WriteLine($"Il nuovo saldo è {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Qualcosa è andato storto");
                }
            }
            else
            {
                Console.WriteLine("Non esiste un conto con questo numero");
            }
        }

        private static void PayIntoAccount()
        {
            int number;
            do
            {
                Console.WriteLine("Inserisci il numero di conto: ");
            } while (!int.TryParse(Console.ReadLine(), out number));
            BankAccount account = BankManager.GetByAccountNumber(number);

            if (account!=null)
            {
                decimal amount = GetAmount("versare");
                account.Balance += amount;
                bool isUpdate = BankManager.UpdateAccount(account);
                if (isUpdate)
                {
                    Console.WriteLine($"Il nuovo saldo è {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Qualcosa è andato storto");
                }
            }
            else
            {
                Console.WriteLine("Non esiste un conto con questo numero");
            }
        }
        private static void AddNewBankAccount()
        {
            //L'utente è già cliente?
            //Se si, aggiungi info sul conto e aggiunto conto sul cliente e nella lista dei conti
            //Se no, aggiungi nuovo cliente sulla lista dei clienti e poi il nuovo conto sul cliente e sulla lista di conti

            char choice;
            string code;
            bool isAdded;
            BankAccount newBankAccount;

            do
            {
                Console.WriteLine("L'utente è già cliente?" +
                    "\n Premi S se si" +
                    "\n Premi N se no");

                choice = Console.ReadKey().KeyChar;

            } while (!(choice == 'S' || choice == 'N'));

            switch (choice)
            {
                case 'S':
                    //Recupero codice cliente
                    code = GetData("codice cliente");

                    //Verifico che il cliente sia effettivamente già cliente
                    AccountHolder accountHolder = BankManager.GetByCode(code);

                    if (accountHolder == null)
                    {
                        Console.WriteLine("Non esiste un cliente con questo codice"); //non è già cliente
                    }
                    else
                    {
                        //Procedo con l'aggiunta del conto
                        newBankAccount = new BankAccount();

                        //associo il cliente al conto
                        newBankAccount.AccountHolder = accountHolder;

                        //associo il codice cliente (fk) al conto
                        newBankAccount.AccountHolderCode = accountHolder.Code;

                        //aggiungo il nuovo conto
                        isAdded = BankManager.AddBankAccount(newBankAccount);

                        if (isAdded)
                        {
                            Console.WriteLine($"Aggiunto conto numero {newBankAccount.Number}" +
                                $" per {accountHolder.LastName} {accountHolder.FirstName}");
                        }
                        else
                        {
                            Console.WriteLine("Ops, qualcosa è andato storto...");
                        }
                    }
                    break;
                case 'N':
                    string firstName = GetData("nome");

                    string lastName = GetData("cognome");

                    AccountHolder newAccountHolder = new AccountHolder()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };

                    bool isNewAccountHolderAdded = BankManager.AddAccountHolder(newAccountHolder);

                    if (isNewAccountHolderAdded)
                    {
                        newBankAccount = new BankAccount();
                        newBankAccount.AccountHolder = newAccountHolder;
                        newBankAccount.AccountHolderCode = newAccountHolder.Code;

                        isAdded = BankManager.AddBankAccount(newBankAccount);

                        if (isAdded)
                        {
                            Console.WriteLine($"Aggiunto conto numero {newBankAccount.Number}" +
                                $" per {newAccountHolder.LastName} {newAccountHolder.FirstName}");
                        }
                        else
                        {
                            Console.WriteLine("Ops, qualcosa è andato storto...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ops, qualcosa è andato storto...");
                    }


                    break;
            }
        }

        private static decimal GetAmount(string value)
        {
            decimal amount;
            do
            {
                Console.WriteLine($"Inserisci l'importo che vuoi {value}: ");
            } while (!decimal.TryParse(Console.ReadLine(), out amount));
            return amount;
        }
        private static string GetData(string value)
        {
            string info;
            do
            {
                Console.WriteLine($"Inserisci il {value} del cliente");
                info = Console.ReadLine();
            } while (string.IsNullOrEmpty(info));

            return info;
        }
    }
}