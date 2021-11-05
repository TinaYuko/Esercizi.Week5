using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Esami
{
    public class Corso
    {
        /* Un Corso associato (al Corso di Laurea, per esempio, Analisi I in Ingegneria) ha:
            • Id (int)
            • Nome
            • CFU
            • Codice Corso di laurea
            Un esame tiene conto del corso e se è passato o non passato.*/

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CreditiFormativi { get; set; }
        public int IdCorsoRiferimento { get; set; }

        

        public Corso()
        {

        }
    }
}
