using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Bank_Account_Management_System
{
    public abstract class BankAccount 
    ///<summary>
    ///This is an example of:
    ///1. Abstraction where the internal details of the class are hidden and the concept of a general bank account are abstracted.
    ///2. Realization/Implementation: the BankAccount class implements the two different interfaces.
    ///</summary>
    {
        // These getters and setters are examples of encapsulation where the attributes themselves are hidden but their return value is made availabe through getters and setters
        public int AccountNumber { get; set; }
        public double Balance {get; set;}
        protected string AccHolName {get; set;}
        protected string AccType { get; set; }
        private double interestrate = 0.05; //5% default interest applied - this is an encapsulated data member of the bankaccount class
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
        public abstract double CalculateInterest(double amount);

        public void PrintTransactionHistory()
        {
            Console.WriteLine($"Transaction History for {AccHolName} with {AccType}:");
            foreach (Transaction T in ListofTransactions)
            {
                Console.WriteLine($"{T.TransactionType}: ${T.TransactionAmount}");
            }
        }

        public abstract void Deposit(double amount);
        public abstract void Deposit(int amount);
        public abstract void Withdraw(double amount);
        public abstract void Withdraw(int amount);
        public abstract void BankCharges();
        public abstract void InterestAccrual();
    } 
}