using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_1
{
    public class Prodotto
    {
        /*  I prodotti sono oggetti che possiedono:
            • un Id
            • una Codice
            • un Nome
            • una Categoria (cosmetici, integratori, infusi)
            • una Prezzo
        */

        public int Id { get; set; }
        public string Codice { get; set; }
        public Categoria Categoria { get; set; }
        public string Nome { get; set; }
        public double Prezzo { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"[{Id}] - {Codice} {Nome} in {Categoria}. Prezzo: {Prezzo} euro");
        }

        public Prodotto()
        {

        }
        public Prodotto(string code, string name, double price, Categoria category)
        {

            Codice = code;
            Nome = name;
            Prezzo = price;
            Categoria = category;

        }
    }

   public enum Categoria
    {
        Cosmetici, Integratori, Infusi
    }
}
