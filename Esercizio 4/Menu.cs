using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    public static class Menu
    {
        internal static void Start()
        {

            Bolletta nuovaBolletta = new Bolletta();
            Console.WriteLine("Benvenuto nel portale Bollette di Enel Energia.");
           
            //All'accesso, l'utente inserisce Codice Fiscale (verifico che esista questo cliente)
            string codFiscale = GetData("Codice Fiscale");
            Utente utente = EnelManager.GetByCF(codFiscale);
            if (utente==null)
            {
                Console.WriteLine("Non esiste nessuna corrispondenza con questo Codice Fiscale");
            }
            else
            {
                //L'utente inserisce i propri dati (kwh consumati) per calcolare la nuova bolletta e aggiungerla
                //al suo storico bollette.
                CalcoloBolletta();
                nuovaBolletta.StampaBolletta();
            }




        }

       

        private static Bolletta CalcoloBolletta()
        {
            string name = GetData("nome");
            string surname = GetData("cognome");

            Console.Write("Inserisci KWh consumati: ");
            double kwh = double.Parse(Console.ReadLine());
            Utente utente = new Utente(name, surname);

            Bolletta bolletta = new Bolletta(kwh);
            bolletta.Intestatario = utente;

            return bolletta;
        }

        private static string GetData(string value)
        {
            string info;
            do
            {
                Console.WriteLine($"Inserisci {value}");
                info = Console.ReadLine();
            } while (string.IsNullOrEmpty(info));

            return info;
        }


    }

}
