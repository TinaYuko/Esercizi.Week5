using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_1
{
    public static class ErboristeriaManager
    {
        public static List<Prodotto> prodotti = new List<Prodotto>()
        {
            new Prodotto
            {
                Id = 1,
                Codice = "P01",
                Nome = "Fondotinta Clinique",
                Categoria = Categoria.Cosmetici,
                Prezzo = 24.90
            },
            new Prodotto
            {
                Id = 2,
                Codice = "P02",
                Nome = "The Matcha",
                Categoria = Categoria.Infusi,
                Prezzo = 10.90
            },
            new Prodotto
            {
                Id = 3,
                Codice = "P03",
                Nome = "Vitamina C",
                Categoria = Categoria.Integratori,
                Prezzo = 7.90
            },
            new Prodotto
            {
                Id = 4,
                Codice = "P04",
                Nome = "Vitamina D",
                Categoria = Categoria.Integratori,
                Prezzo = 8.90
            },
            new Prodotto
            {
                Id = 5,
                Codice = "P05",
                Nome = "Mascara Lancome",
                Categoria = Categoria.Cosmetici,
                Prezzo = 25.90
            },
            new Prodotto
            {
                Id = 6,
                Codice = "P06",
                Nome = "Camomilla l'Angelica",
                Categoria = Categoria.Infusi,
                Prezzo = 4.90
            }

        };

        public static void GetProductByPrice()
        {
            bool continua = true;
            do
            {
                Console.WriteLine("Premi \n[1] per vedere i prodotti da mortaccio di fascia 0-15 euro" +
                    "\n[2] per vedere i prodotti di fascia 15-50 euro" +
                    "\n[3] per vedere i prodotti di fascia 50-100 euro" +
                    "\n[4] per vedere i prodotti che tanto non ti puoi permettere." +
                    "\n[0] per uscire e non rompere più le palle.");

                int scelta;
                do
                {
                    Console.WriteLine("Fai la tua scelta tra le possibili richieste");
                }
                while (!int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 5);

                switch (scelta)
                {
                    case 0:
                        continua = false;
                        break;
                    case 1:
                        List<Prodotto> prodottiMortacci = new List<Prodotto>();
                        foreach (var item in prodotti)
                        {
                            if (item.Prezzo>=0 && item.Prezzo<15)
                            {
                                prodottiMortacci.Add(item);
                            }
                        }
                        StampaLista(prodottiMortacci);
                break;
                    case 2:
                        List<Prodotto> prodottiMenoMortacci = new List<Prodotto>();
                        foreach (var item in prodotti)
                        {
                            if (item.Prezzo >= 15 && item.Prezzo < 50)
                            {
                                prodottiMenoMortacci.Add(item);
                            }
                        }
                        StampaLista(prodottiMenoMortacci);
                        break;
                    case 3:
                        List<Prodotto> prodottiCostosi = new List<Prodotto>();
                        foreach (var item in prodotti)
                        {
                            if (item.Prezzo >= 50 && item.Prezzo < 100)
                            {
                                prodottiCostosi.Add(item);
                            }
                        }
                        StampaLista(prodottiCostosi);
                        break;
                    case 4:
                        List<Prodotto> prodottiShishi = new List<Prodotto>();
                        foreach (var item in prodotti)
                        {
                            if (item.Prezzo >= 100)
                            {
                                prodottiShishi.Add(item);
                            }
                        }
                        StampaLista(prodottiShishi);
                        break;

                }
            } while (continua);
        }

        internal static bool AddProduct(Prodotto nuovoProdotto)
        {
            if (nuovoProdotto != null)
            {
                //genero id per il nuovo elemento
                int id = GnerateId();

                //assegno al prodotto
                nuovoProdotto.Id = id;

                //aggiungo alla lista
                prodotti.Add(nuovoProdotto);
                return true;
            }
            return false;
        }

        private static int GnerateId()
        {
            //conto quanti elementi ci sono 
            int newId = 0;
           
            if (prodotti.Count!=0)
            {
                //recupero l'ultimo elemento
                int count = prodotti.Count;
                Prodotto p = prodotti[count - 1];
            //genero il nuovo id come ultimo id +1
            newId = p.Id + 1;
            }
            else
            {
                newId = 1;
            }
            return newId;
        }

        public static double AggiornaPrezzo()
        {
            Console.WriteLine("I prodotti presenti in erboristeria sono: ");
            StampaLista(prodotti);
            Console.Write("Scrivi il codice del prodotto da aggiornare: ");
            string code = Console.ReadLine();
            Prodotto p = GetByCode(code);
            if (p == null)
            {
                Console.WriteLine("Prodotto non pervenuto. Codice errato!");

            }
            else
            {
                double prezzo;
                do
                {
                    Console.Write("Inserisci prezzo: ");
                }
                while (!(double.TryParse(Console.ReadLine(), out prezzo) && prezzo > 0));
                p.Prezzo = prezzo; 
                
            }
            return p.Prezzo;
        }

        public static void CheckByCategory()
        {
            Categoria c = InserisciCategoria();
            List<Prodotto> prodottiPerCategoria = new List<Prodotto>();
            foreach (var item in prodotti)
            {
                if (item.Categoria == c)
                {
                    prodottiPerCategoria.Add(item);
                }
            }
            StampaLista(prodottiPerCategoria);
        }

        public static void StampaLista(List<Prodotto> prodottiPerCategoria)
        {
            if (prodottiPerCategoria.Count == 0)
            {
                Console.WriteLine("Non ci sono prodotti!");
            }
            else
            {
                foreach (var item in prodottiPerCategoria)
                {
                    Console.WriteLine($"[{item.Id}] - {item.Codice} {item.Nome} in {item.Categoria}. Prezzo: {item.Prezzo} euro");

                }
            }
        }

        public static Categoria InserisciCategoria()
        {
            Console.WriteLine("Inserisci la categoria");
            Console.WriteLine($"Premi {(int)Categoria.Cosmetici} per {Categoria.Cosmetici}. ");
            Console.WriteLine($"Premi {(int)Categoria.Integratori} per {Categoria.Integratori}. ");
            Console.WriteLine($"Premi {(int)Categoria.Infusi} per {Categoria.Infusi}. ");
            int categoria;
            do
            {
                Console.WriteLine("Fai la tua scelta");

            }
            while (!(int.TryParse(Console.ReadLine(), out categoria) && categoria >= 0 && categoria < 3));
            return (Categoria)categoria; //Faccio il cast affinché con l'enum non mi restituisca il numero ma proprio il genere

        }
        public static void CheckExpensiveProd()
        {
            double max = prodotti[0].Prezzo;
            int indice;
            for (int i = 1; i < prodotti.Count; i++)
            {
                if (max < prodotti[i].Prezzo)
                {
                    max = prodotti[i].Prezzo;
                }
            }

            //Risalgo all'indice
            for (int i = 0; i < prodotti.Count; i++)
            {
                if (prodotti[i].Prezzo == max)
                {
                    Console.WriteLine("\nI dati del prodotto più costoso sono: ");
                    indice = i;
                    Console.WriteLine($"{prodotti[indice].Codice} - {prodotti[indice].Nome} in {prodotti[indice].Categoria}: {prodotti[indice].Prezzo} euro ");
                }
            }
        }

        public static void GetProductByCode()
        {
            //recupero codice inserito
            Console.Write("Inserisci codice del prodotto: ");
            string code = Console.ReadLine();
            Prodotto p = GetByCode(code);

            if (p != null)
            {
                p.PrintInfo();
            }
            else
            {
                Console.WriteLine("Non esiste un prodotto con questo codice!");
            }
        }

        public static Prodotto GetByCode(string code)
        {
            foreach (Prodotto p in prodotti)
            {
                if (p.Codice == code)
                { return p; }

            }
            return null;
        }


    }
}
