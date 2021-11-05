using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esercizio_3.Entities;

namespace Esercizio_3
{
    public static class BankManager
    {
        static List<AccountHolder> accountHolders = new List<AccountHolder>(); //tutti i clienti della banca

        static List<BankAccount> bankAccounts = new List<BankAccount>(); //tutti i conti della banca

        internal static AccountHolder GetByCode(string code)
        {
            foreach (AccountHolder a in accountHolders)
            {
                if (a.Code == code)
                {
                    return a;
                }
            }

            return null;
        }

        public static bool DeleteAccount(BankAccount accountToDelete)
        {
            if (accountToDelete!=null)
            {
                //rimuoverlo dalla lista dei conti
                bankAccounts.Remove(accountToDelete);
                //rimuoverlo dalla lista dei conti dell'intestatario
                accountToDelete.AccountHolder.BankAccounts.Remove(accountToDelete);
                return true;
            }
            return false;
        }
        internal static bool AddBankAccount(BankAccount newBankAccount)
        {
            if (newBankAccount != null)
            {
                //generare numero di conto
                int number = GenerateAccountNumber();

                //Associo il numero generato al nuovo conto
                newBankAccount.Number = number;

                //aggiungere il conto alla lista di conti 
                bankAccounts.Add(newBankAccount);

                //aggiungo il conto alla lista di conti dell'intestatario
                AccountHolder a = newBankAccount.AccountHolder; //intestatario proprio del nuovo conto -> newBankAccount
                List<BankAccount> accounts = a.BankAccounts; //lista di conti dell'intestatario di newBankAccount
                accounts.Add(newBankAccount);

                //equivale a:
                //newBankAccount.AccountHolder.BankAccounts.Add(newBankAccount);
                return true;
            }

            return false;

        }

        private static int GenerateAccountNumber()
        {
            int count = bankAccounts.Count;
            int newNumberAccount;

            if (count > 0)
            {
                int lastNumberAccount = bankAccounts[count - 1].Number;
                newNumberAccount = lastNumberAccount + 1;
            }
            else
            {
                newNumberAccount = 1;
            }

            return newNumberAccount;
        }

        internal static bool DeleteAccount(object accountToDelete)
        {
            throw new NotImplementedException();
        }

        internal static bool UpdateAccount(BankAccount account)
        {
            if (account != null)
            {
                return true;
            }
            else return false;
        }

        internal static bool AddAccountHolder(AccountHolder newAccountHolder)
        {
            if (newAccountHolder != null)
            {
                newAccountHolder.Code = GenerateCode(newAccountHolder.FirstName, newAccountHolder.LastName);
                accountHolders.Add(newAccountHolder);

                return true;
            }
            return false;
        }

        private static string GenerateCode(string firstName, string lastName)
        {
            string code = null;

            do
            {
                Random random = new Random();
                int randomNum = random.Next();
                code = $"{firstName[0]}{lastName[0]}{randomNum}";
            }
            while (GetByCode(code) != null); //se trovo un cliente con il codice che è stato generato,
            //sorteggio un altro numero random e quindi genero un nuovo codice

            return code;

        }
        internal static BankAccount GetByAccountNumber(int number)
        {
            foreach (BankAccount item in bankAccounts)
            {
                if (item.Number==number)
                {
                    return item;
                }

            }
            return null;
        }
    }
}