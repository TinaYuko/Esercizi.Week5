using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_1
{
   public static class Menu
    {
        internal static void Start()
        {
            bool exit = true;
            do
            {
                Console.WriteLine("[1] Stampa i dettagli del prodotto con prezzo massimo" +
                    "\n[2] Stampa i dettagli di un prodotto" +
                    "\n[3] Stampa i prodotti di una certa categoria" +
                    "\n[4] Aggiorna il prezzo di un prodotto" +
                    "\n[5] Stampa dati relativi ai prodotti per fascia di prezzo" +
                    "\n[6] Aggiungi un nuovo prodotto"
                    + "\n[Q] Esci");
                char choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        ErboristeriaManager.CheckExpensiveProd();
                        break;
                    case '2':
                        ErboristeriaManager.GetProductByCode();
                        break;
                    case '3':
                        ErboristeriaManager.CheckByCategory();
                        break;
                    case '4':
                        ErboristeriaManager.AggiornaPrezzo();
                        break;
                    case '5':
                        ErboristeriaManager.GetProductByPrice();
                        break;
                    case '6':
                        AddNewProduct();
                        break;
                    case 'Q':
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, nenno");
                        break;
                }
            } while (exit);
        }

        private static void AddNewProduct()
        {
            //Chiedere all'utente il codice prodotto
            string codice = GetData("codice");
            string name = "";
            Categoria categoria = 0;
            double prezzo = 0;

            //Utente digita il codice, se esiste già questo prodotto, avvisiamo
            Prodotto product = ErboristeriaManager.GetByCode(codice);
            if (product!=null)
            {
                Console.WriteLine("Codice già esistente!");
            }
            //Se non esiste, si chiedono altre info sul prodotto
            else
            {
                name = GetData("nome");
                categoria = (Categoria)ErboristeriaManager.InserisciCategoria();
                prezzo = ErboristeriaManager.AggiornaPrezzo();

            }
            //E poi aggiungo il prodotto
            //Prodotto nuovoProdotto = new Prodotto();
            //nuovoProdotto.Codice = codice;
            //nuovoProdotto.Nome = name;
            //nuovoProdotto.Categoria = (Categoria)Categoria;

            Prodotto nuovoProdotto = new Prodotto(codice, name, prezzo, categoria);

            bool isAdded = ErboristeriaManager.AddProduct(nuovoProdotto);
            if (isAdded)
                Console.WriteLine("Prodotto aggiunto!");
            else
                Console.WriteLine("Non è andata bene, mi dispi");

        }

        private static string GetData(string value)
        {
            string code;
            do
            {
                Console.Write($"Inserisci il {value} del prodotto: ");
                code = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(code));

            return code;
        }
    }
}
