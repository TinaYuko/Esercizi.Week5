using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    public class Utente
    {
        public Utente(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        //L'utente ha Codice Fiscale, Nome, Cognome, Bollette.
        //Un utente può avere più bollette, la bolletta ha un solo utente associato.

        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public List<Bolletta> Bollette { get; set; } = new List<Bolletta>();
        public string Name { get; }
        public string Surname { get; }
    }
}
