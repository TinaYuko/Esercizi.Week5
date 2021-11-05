using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    public class DistributoreManager
    {
        static Dictionary<int, Snack> distributoreDictionary = new Dictionary<int, Snack>();


        public static void AggiungoSnack()
        {
            Snack snack1 = new Snack() { Id = 1, Nome = "Bounty", Prezzo = 1 };
            Snack snack2 = new Snack() { Id = 2, Nome = "Croccantelle", Prezzo = 0.5 };
            Snack snack3 = new Snack() { Id = 3, Nome = "Kinder Bueno", Prezzo = 1.20 };

            distributoreDictionary.Add(1, snack1);
            distributoreDictionary.Add(1, snack2);
            distributoreDictionary.Add(1, snack3);
        }

        internal static void VisualizzaProdotti()
        {
            
            foreach (var item in distributoreDictionary)
            {
                Console.WriteLine($"\nCODICE: {item.Key}" + $"NOME: {item.Value.Nome}" +
                     $"PREZZO: {item.Value.Prezzo}");
            }
        }

        public static Snack GetSnackByKey(int chiave)
        {
            if (distributoreDictionary.ContainsKey(chiave))
            {
                return distributoreDictionary[chiave];
            }

            return null;
        }

        public static Snack SearchKey(int chiave)
        { 
            foreach (var item in distributoreDictionary)
            {
                if (item.Key == chiave)
                {
                    return item.Value;
                }

            }
            return null;
        }
        


    }
}
