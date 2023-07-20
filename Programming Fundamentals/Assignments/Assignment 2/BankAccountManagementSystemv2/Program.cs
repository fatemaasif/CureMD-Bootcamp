using System;
using System.Diagnostics.CodeAnalysis;

namespace BankAccountManagementSystemv2
{
    public abstract class BankAccount
    {
        private string accountNumber;
        private string accountHolderName;
        protected double balance { get; set; }
        protected string AccountType { get; set; }
        protected double interestRate { get; set; }
        public List<Transaction> transactionHistory = new List<Transaction>(); 

        protected BankAccount(string accountNumber, string accountHolderName)
        {
            this.accountNumber = accountNumber;
            this.accountHolderName = accountHolderName;
            balance = 0.00;
        }
        public string AccountNumber() { return accountNumber; }
        public string AccountHolderName() {  return accountHolderName; }
        abstract protected double CalculateInterest(double amount);
        public void Deposit() 
            ///<summary>first time deposit on account creation for savings, checking and investment accounts</summary>
        {
            if (transactionHistory.Count < 1) 
            {
                Transaction firsttransaction = new Transaction("Deposit", 100);
                balance += 100;
                transactionHistory.Add(firsttransaction);
            }
            Console.WriteLine($"You are eligible for a free first time deposit of $100. New balance: {balance}");
        }
        public void Deposit(double amount)
        {
            balance+= amount;
        }
    }

    public interface ITransaction
    {
        void ExecuteTransaction(Transaction transaction);
        void PrintTransaction();
        
    }

    public class SavingsAccount : BankAccount, ITransaction 
    {
        protected double interestRate = 0.02; //2% interest
        public SavingsAccount(string accountNumber, string accountHolderName):base(accountNumber, accountHolderName)
        {
            AccountType = "Savings Account";
            Console.WriteLine($"Hi, {accountHolderName}, you have succesfully created a Savings Account with us. Thank you!");
            Deposit();
            Console.WriteLine();
        }
        protected override double CalculateInterest(double amount) { return amount * interestRate; }

        public void ExecuteTransaction(Transaction transaction)
        {
            switch (transaction.transactionType)
            {
                case "Deposit":
                    Deposit(transaction.transactionAmount);
                    transactionHistory.Add(transaction);
                    break;
                case "Withdraw":
                    
                    break;
                default:
                    break;
            }
            PrintTransaction();
        }
        public void PrintTransaction()
        { Console.WriteLine($"Your transaction has been executed sucessfully. New balance: {balance}"); }
    }

    public class CheckingAccount : BankAccount
    {
        protected double interestRate = 0.05; //5% interest
        public CheckingAccount(string accountNumber, string accountHolderName) : base(accountNumber, accountHolderName)
        {
            AccountType = "Checking Account";
            Console.WriteLine($"Hi, {accountHolderName}, you have succesfully created a Checking Account with us. Thank you!");
            Deposit();
            Console.WriteLine();
        }
        protected override double CalculateInterest(double amount) { return amount * interestRate; }
    }

    public class LoanAccount : BankAccount
    {
        protected double interestRate = 0.10; //10% interest
        public LoanAccount(string accountNumber, string accountHolderName) : base(accountNumber, accountHolderName)
        {
            AccountType = "Loan Account";
            Console.WriteLine($"Hi, {accountHolderName}, you have succesfully created a Loan Account with us. Thank you!");
            Console.WriteLine();
        }
        protected override double CalculateInterest(double amount) { return amount * interestRate; }
    }

    public class InvestmentAccount : BankAccount
    {
        protected double interestRate = 0.20; //20% interest
        public InvestmentAccount(string accountNumber, string accountHolderName) : base(accountNumber, accountHolderName)
        {
            AccountType = "Investment Account";
            Console.WriteLine($"Hi, {accountHolderName}, you have succesfully created a Investment Account with us. Thank you!");
            Deposit();
            Console.WriteLine();
        }
        protected override double CalculateInterest(double amount) { return amount * interestRate; }
    }

    public class Transaction
    {
        public string transactionType;
        public double transactionAmount;
        public Transaction(string transactionType, double transactionAmount)
        {
            this.transactionType = transactionType;
            this.transactionAmount = transactionAmount;
        }
        
	}


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}