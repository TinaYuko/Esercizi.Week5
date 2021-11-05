using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
   public static class EnelManager
    {
        static List<Utente> utenti = new List<Utente>(); //tutti gli utenti
        static List<Bolletta> bollette = new List<Bolletta>(); //tutte le bollette

        internal static Utente GetByCF(string codFiscale)
        {
            foreach (Utente item in utenti)
            {
                if (item.CodiceFiscale==codFiscale)
                {
                    return item;
                }
            }
            return null;
        }


    }
}
