using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Esami
{
    public class Studente
    {
        /*Lo studente è definito con:
            • Matricola(univoca)
            • Nome
            • Cognome
            • Anno di Nascita
            • Richiesta Laurea(bool)
            • CFU Accumulati
            • Esami
            • Codice Corso di laurea
            Lo studente si iscrive a un solo corso di laurea.
            A un corso di laurea possono essere iscritti
            più studenti.*/
        public int Matricola { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int AnnoDiNascita { get; set; }
        public bool RichiestaLaurea { get; set; }
        public int CfuAccumulati { get; set; }
        public int IdCorsoDiLaurea { get; set; }
        public List<Esame> esami { get; set; } = new List<Esame>();


        public Studente() { }
        public Studente(string nome, string cognome, int anno)
        {
            Nome = nome; Cognome = cognome; AnnoDiNascita = anno;
            RichiestaLaurea = false;
        }

    }
}
