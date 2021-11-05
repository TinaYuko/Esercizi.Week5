using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Esami
{
    public class GestoreEsami


    {
        public static List<Corso> corsi = new List<Corso>();
        public static List<CorsoDiLaurea> corsiDiLaurea = new List<CorsoDiLaurea>();
        public static List<Esame> esami = new List<Esame>();
        public static List<Studente> studenti = new List<Studente>();


        internal static void AddData()
        {
            CorsoDiLaurea Matematica = new CorsoDiLaurea { Id = 1, Nome = "Matematica", AnniDiCorso = 3, Cfu = 180 };
            CorsoDiLaurea Fisica = new CorsoDiLaurea { Id = 2, Nome = "Fisica", AnniDiCorso = 3, Cfu = 180 };
            CorsoDiLaurea Informatica = new CorsoDiLaurea { Id = 3, Nome = "Informatica", AnniDiCorso = 3, Cfu = 180 };
            CorsoDiLaurea Ingegneria = new CorsoDiLaurea { Id = 4, Nome = "Ingegneria", AnniDiCorso = 3, Cfu = 180 };
            CorsoDiLaurea Lettere = new CorsoDiLaurea { Id = 5, Nome = "Lettere", AnniDiCorso = 3, Cfu = 180 };

            Studente studente1 = new Studente { Matricola = 1234, Nome = "Nenno", Cognome = "Lello", AnnoDiNascita = 1998, CfuAccumulati = 127, RichiestaLaurea = false, IdCorsoDiLaurea = 1 };
            Studente studente2 = new Studente { Matricola = 1235, Nome = "Nenna", Cognome = "Acaso", AnnoDiNascita = 2001, CfuAccumulati = 112, RichiestaLaurea = false, IdCorsoDiLaurea = 2 };
            Studente studente3 = new Studente { Matricola = 2379, Nome = "Tizio", Cognome = "Nonsoniente", AnnoDiNascita = 1995, CfuAccumulati = 10, RichiestaLaurea = false, IdCorsoDiLaurea = 3 };

            Corso Analisi = new Corso { Id = 1, Nome = "Analisi Matematica", CreditiFormativi = 30, IdCorsoRiferimento = 1 };
            Corso Geometria = new Corso { Id = 2, Nome = "Geometria", CreditiFormativi = 40, IdCorsoRiferimento = 2 };
            Corso Logica = new Corso { Id = 3, Nome = "Logica", CreditiFormativi = 25, IdCorsoRiferimento = 1 };

            Corso FisicaT = new Corso { Id = 4, Nome = "Fisica Teorica", CreditiFormativi = 45, IdCorsoRiferimento = 2 };
            Esame esameMatematica = new Esame { Id = 1, Passato = true };

            Matematica.Corsi.Add(Analisi);
            Matematica.Corsi.Add(Geometria);
            Ingegneria.Corsi.Add(Logica);
            Ingegneria.Corsi.Add(FisicaT);
            Informatica.Studenti.Add(studente1);
            Lettere.Studenti.Add(studente2);
            Matematica.Studenti.Add(studente3);

            studente3.esami.Add(esameMatematica);
            studenti.Add(studente1);
            studenti.Add(studente2);
            studenti.Add(studente3);
            esami.Add(esameMatematica);
            corsi.Add(Analisi);
            corsi.Add(FisicaT);
            corsi.Add(Geometria);
            corsi.Add(Logica);
            corsiDiLaurea.Add(Matematica);
            corsiDiLaurea.Add(Fisica);
            corsiDiLaurea.Add(Ingegneria);
            corsiDiLaurea.Add(Informatica);
        }

        internal static Esame GetEsameById(int id)
        {
            foreach (Esame item in esami)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        internal static void PrintEsami()
        {
            foreach (Esame item in esami)
            {
                Console.WriteLine($"Codice: {item.Id} - Nome: {item.Nome}");
            }
        }

        internal static void PrintCorsi()
        {
            foreach (Corso  item in corsi)
            {
                Console.WriteLine($"Codice: {item.Id} - Nome: {item.Nome}");
            }
        }

        internal static Corso GetCorsoById(int id)
        {
            foreach (Corso item in corsi)
            {
                if (item.Id==id)
                {
                    return item;
                }
            } return null;
        }

        internal static CorsoDiLaurea VerificaCorsoLaurea(Studente studente)
        {
            foreach (CorsoDiLaurea item in corsiDiLaurea)
            {
                if (item.Id==studente.IdCorsoDiLaurea)
                {
                    return item;
                }
            } return null;
        }

        internal static bool CheckEsameCorso(Corso materia)
        {
            foreach (CorsoDiLaurea item in corsiDiLaurea)
            {
                if (item.Id==materia.Id)
                {
                    return true;
                }
            }return false;
        }

        internal static bool CheckEsameDato(Corso materia, Studente studente)
        {
            foreach (Esame item in studente.esami)
            {
                if (item.Id==materia.Id)
                {
                    return true;
                }

            } return false;
        }

        internal static bool CheckCfu(Corso materia, Studente studente, CorsoDiLaurea corsoLaurea)
        {
            int cfu;
            cfu = studente.CfuAccumulati + materia.CreditiFormativi;
            if (cfu<=corsoLaurea.Cfu)
            {
                return true;
            } 
            else return false;
        }

        internal static bool VerificaFlag(Studente studente)
        {
            if (studente.RichiestaLaurea==false)
            {
                return true;
            } 
            else return false;
        }

        internal static Studente GetByMatricola(int matricola)
        {
            foreach (Studente item in studenti)
            {
                if (item.Matricola==matricola)
                {
                    return item;
                }
            } return null;
        }

       

         



        
    }
}
