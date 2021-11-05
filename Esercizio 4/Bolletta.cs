using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    public class Bolletta
    {
        //La bolletta ha Quota fissa(40 €), kWh consumati, Importo totale e Utente(intestatario).
        //Un utente può avere più bollette, la bolletta ha un solo utente associato.

        public double KWh { get; set; }
        public decimal ImportoTotale { get; set; }
        public Utente Intestatario { get; set; }
        const decimal Quota = 40;

        public Bolletta(double kwh)
        {
            KWh = kwh;
            ImportoTotale = (decimal)(kwh * 10) + Quota;
        }

        public Bolletta()
        {
        }
        public string StampaBolletta()
        {
           return $"L'intestatario: {Utente.Nome} {Utente.Cognome}, ha consumato {KWh} KWh e deve pagare {ImportoTotale} Euro";
        }
    }

    
}
