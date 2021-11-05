using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    public static class Menu
    {
        public static void Start()
        {
            DistributoreManager.AggiungoSnack();

            /* Mostrare un menu all’utente per far scegliere lo snack desiderato
               Una volta scelto lo snack, chiedere all’utente di inserire il denaro necessario.
               Se la quota inserita non è sufficiente richiedere nuovamente l’aggiunta di denaro e sommarla a
               quella già inserita.
               Rieffettuare il controllo fino al raggiungimento o superamento del prezzo dello snack scelto.
               Se il totale inserito è uguale al prezzo dello snack allora mostrare a video “Erogazione dello snack”.
               Se il totale supera il prezzo dello snack, mostrare a video “Erogazione dello snack” ed anche il
               messaggio con il resto “Resto erogato : X.XX €” 
            */


            char goOn = 'y';
            while (goOn == 'y')
            {
                Console.WriteLine("I prodotti presenti nel distributore sono:");
            DistributoreManager.VisualizzaProdotti();
            Console.Write("Scegli lo snack da comprare: ");
            int code = Convert.ToInt32(Console.ReadLine());
            DistributoreManager.SearchKey(code);
            Snack snackScelto = DistributoreManager.GetSnackByKey(code);

            if (snackScelto != null)
            {
                Console.Write($"Hai scelto lo snack: {code} {snackScelto} \n");
                ManagePayment(snackScelto.Prezzo);
                Console.WriteLine("Erogazione snack");
            }
            else
            {
            
                Console.WriteLine("Non esiste un prodotto con questo codice.");
                
            }

            Console.WriteLine("Vuoi acquistare altri snack? Premi y per confermare");

            goOn = Console.ReadKey().KeyChar;

            Console.WriteLine();
        }
        Console.WriteLine("Arrivederci");

        }
            public static void ManagePayment(double price)
            {
                double cash;
                double tot = 0;
                double change;

                Console.Write("Inserisci importo: ");
                do
                {
                    double.TryParse(Console.ReadLine(), out cash);
                    tot += cash;
                    if (tot < price)
                    {
                        Console.WriteLine($"Hai inserito {tot} euro");
                        Console.WriteLine($"Devi ancora inserire {price - tot} euro");
                    }
                } while (tot < price);

                change = tot - price; //resto


                if (change > 0)
                { Console.WriteLine($"Resto: {change}"); }
            }
        
    }
}
