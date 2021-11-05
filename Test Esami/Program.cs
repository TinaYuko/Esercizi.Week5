using System;

namespace Test_Esami
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Creare una Console App che gestisca l’iscrizione ad un esame di uno Studente.
          
           
           
            All’accesso, uno studente può:
            • Prenotarsi ad un Esame
            NOTA: Uno studente può prenotarsi a un esame solo se:
            - flag Richiesta Laurea è falso, ovvero non ha fatto domanda di laurea
            - presente nel Corso di Laurea associato allo studente e non lo ha già tra i suoi Esami
            (passato o non passato)
            - i CFU del corso associato all’esame non superino i CFU massimi del Corso di laurea
            Nel caso le condizioni siano verificate, lo studente aggiunge l’esame alla sua raccolta di
            Esami.
            • Verbalizzare un Esame prenotato.
            NOTA: Bisogna aggiornare i CFU accumulati dallo studente, mettere il flag ‘Passato’
            sull’esame e verificare se con tale esame sono stati raggiunti i CFU necessari per richiedere
            la laurea (e quindi mettere il flag RichiestaLaurea a true);
            Suggerimento:
            - Preparare dei dati di prova opportuni per fare i test ➔ inizializzare corsi di laurea.
            Carica la prova pratica su Github con Nome e Cognome.*/
            Menu.Start();
        
        }
    }
}
