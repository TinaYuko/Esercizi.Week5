using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Esami
{
    public class CorsoDiLaurea
    {
        /*Lo studente si iscrive a un solo corso di laurea. A un corso di laurea possono essere iscritti
            più studenti.
            Un Corso di laurea è dato da:
            • Codice (esempio LM-21, L-9, LM-56…),
            • Nome,
            • Anni Di Corso,
            • CFU per ottenere la laurea
            • Corsi associati (materie)
            • Studenti
          Limitare i possibili nomi dei Corsi di Laurea, per esempio, tra Fisica, Informatica, Ingegneria,
          Lettere, Filosofia (o altri a piacere).*/

        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnniDiCorso { get; set; }
        public int Cfu { get; set; }
        public List<Corso> Corsi { get; set; } = new List<Corso>();
        public List<Studente> Studenti { get; set; } = new List<Studente>();

        public override string ToString()
        {
            return $"{Nome} per {AnniDiCorso} anni";
        }
        public CorsoDiLaurea()
        {

        }
    }
}
