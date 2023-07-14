using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System_v2
{
    public abstract class BankAccount: Transaction
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        protected string AccHolName { get; set; }
        public string AccType { get; set; }
        public List<Transaction> ListofTransactions = new List<Transaction>(); //List of all transactions
        public BankAccount(int accnum, string holname, double bal)
        {
            AccountNumber = accnum;
            AccHolName = holname;
            Balance = bal;
        }
        public void DisplayAccountInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Account Holder's Name: " + AccHolName);
            Console.WriteLine("Total Balance: " + Balance);
            Console.WriteLine();
        }

    }
}
