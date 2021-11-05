using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Esami
{
    public class Menu
    {
        internal static void Start()
        {
            GestoreEsami.AddData();
            bool exit;
            int scelta;

            do
            {
                Console.WriteLine("\n\nPremi " +
                    "\n1 per prenotare un esame" +
                    "\n2 per verbalizzare un esame" +
                    "\n0 per uscire");

                exit = int.TryParse(Console.ReadLine(), out scelta);

                switch (scelta)
                {
                    case 0:
                        exit = false;
                        break;
                    case 1:
                        Prenotazione();
                        break;
                    case 2:
                        VerbalizzazioneEsame();
                        break;
                    default:
                        Console.WriteLine("\nScelta non valida.");
                        break;
                }
            } while (exit);



        }

        private static void VerbalizzazioneEsame()
        {
            int matricola = GetMatricola();
            Studente studente = GestoreEsami.GetByMatricola(matricola);
            bool flag = GestoreEsami.VerificaFlag(studente);
            if ((studente != null) && (flag = true))
            {
                //chiedo l'esame da verbalizzare
                Console.WriteLine("Elenco esami: ");
                GestoreEsami.PrintEsami();
                int id = GetIdCorso();
                Corso esame = GestoreEsami.GetCorsoById(id);
                if (esame != null)
                {
                    CorsoDiLaurea corsoLaurea = GestoreEsami.VerificaCorsoLaurea(studente);
                    if (corsoLaurea != null)
                    {
                        EsamePassato(studente, esame);
                    }
                    else Console.WriteLine("Si è verificato un errore..");
                }
                else Console.WriteLine("Nessun esame con questo ID");
            }
            else Console.WriteLine("Si è verificato un errore");
        }

        private static void EsamePassato(Studente studente, Corso esame)
        {
            studente.CfuAccumulati += esame.CreditiFormativi;
            studente.esami.Find(esame => esame.Id == esame.Id).Passato = true;
            Console.WriteLine($"Esame verbalizzato correttamente! Ora hai: {studente.CfuAccumulati} cfu.");
        }

        public static void Prenotazione()
        {
            //chiedo matricola
            int matricola = GetMatricola();
            //verifico se è giusta
            Studente studente = GestoreEsami.GetByMatricola(matricola);
            bool flag = GestoreEsami.VerificaFlag(studente);

            if (studente != null && flag == true)
            {
                //chiedo il corso da prenotare
                Console.WriteLine("Elenco esami: ");
                GestoreEsami.PrintCorsi();
                int id = GetIdCorso();
                Corso materia = GestoreEsami.GetCorsoById(id);
                if (materia != null)
                {
                    CorsoDiLaurea corsoLaurea = GestoreEsami.VerificaCorsoLaurea(studente);
                    if (corsoLaurea != null)
                    {
                        bool esameInCorso = GestoreEsami.CheckEsameCorso(materia);
                        if (esameInCorso)

                        {
                            bool esameDato = GestoreEsami.CheckEsameDato(materia, studente);
                            if (esameDato == false)
                            {
                                bool checkfu = GestoreEsami.CheckCfu(materia, studente, corsoLaurea);
                                Console.WriteLine("Esame prenotato!");
                            }
                        }
                        else Console.WriteLine("L'esame non è presente nel tuo corso di Laurea!");
                    }
                    else Console.WriteLine("Si è verificato un errore..");
                }
                else Console.WriteLine("Nessun corso per questo ID");
            }
            else Console.WriteLine("Si è verificato un errore");
        }

        private static int GetIdCorso()
        {
            int id;
            do
            {
                Console.WriteLine("Inserisci l'Id del corso: ");
            } while (!int.TryParse(Console.ReadLine(), out id));
            return id;
        }
        private static int GetMatricola()
        {
            int matricola;
            do
            {
                Console.WriteLine("Inserisci matricola: ");

            } while (!int.TryParse(Console.ReadLine(), out matricola));
            return matricola;
        }

    }
   
}
