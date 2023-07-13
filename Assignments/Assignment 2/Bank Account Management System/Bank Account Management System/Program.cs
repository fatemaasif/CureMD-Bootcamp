using System;
using System.Collections.Generic;


namespace Bank_Account_Management_System
{
    public interface IBankAccount
        /// <summary> This is an interface with functions that all accounts must have in order to fit the characteristics of a bank account
    {
        void Deposit(int amount);
        void Withdraw(int amount);
    }
    public interface ITransaction //This is an interface with functions that all accounts must have in order to fit the characteristics of a bank account
    {
        void ExecuteTransaction(decimal amount, string transctiontype);
        void PrintTransaction(decimal transactionamount, string transctiontype);
    }
    public abstract class BankAccount:IBankAccount,ITransaction 
    ///<summary>
    ///This is an example of:
    ///1. Abstraction where the internal details of the class are hidden and the concept of a general bank account are abstracted.
    ///2. Realization/Implementation: the BankAccount class implements the two different interfaces.
    ///</summary>
    {
        // These getters and setters are examples of encapsulation where the attributes themselves are hidden but their return value is made availabe through getters and setters
        protected int AccountNumber {get; set;}
        protected double Balance {get; set;}
        protected string AccHolName {get; set;}
        private double interestrate = 0.05; //5% default interest applied
        public BankAccount(int accnum, string holname, double bal)
        {
            AccountNumber = accnum;
            AccHolName = holname;
            Balance = bal;
        }
        public virtual void Deposit(int depositamount)
        {
            ExecuteTransaction(depositamount, "Deposit");
        }
        public virtual void Deposit(double depositamount) //Example of static polymorphism: The deposit method is overloaded with a double type arg
        {
            ExecuteTransaction(Convert.ToDecimal(depositamount), "Deposit");
        }
        public virtual void Withdraw(int withdrawamount)
        {
            ExecuteTransaction(withdrawamount, "Withdraw");
        }
        public virtual void Withdraw(double withdrawamount) //Example of static polymorphism: The deposit method is overloaded with a double type arg
        {
            ExecuteTransaction(Convert.ToDecimal(withdrawamount), "Withdraw");
        }
        public void DisplayAccountInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Account Holder's Name: " + AccHolName);
            Console.WriteLine("Total Balance: " + Balance);
            Console.WriteLine();
        }
        public virtual double CalculateInterest(double amount)
        {
            return amount * interestrate; 
        } 
        public void ExecuteTransaction(decimal transactionamount, string transctiontype)
        {
            if(transctiontype== "Deposit") { Balance += Convert.ToDouble(transactionamount); }
            if (transctiontype == "Withdraw") { Balance -= Convert.ToDouble(transactionamount); }
            PrintTransaction(transactionamount, transctiontype);
        }
        public void PrintTransaction(decimal transactionamount, string transctiontype)
        {
            if (transctiontype == "Deposit") { Console.WriteLine("$" + transactionamount + " has been deposited into your account"); }
            if (transctiontype == "Withdraw") { Console.WriteLine("$" + transactionamount + " has been withdrawn from your account"); }
            Console.WriteLine("Your current balance is $" + Balance);
            Console.WriteLine();
        }
    } 
    /// <summary>
    /// This is an example of inheritance: The classes that follow (up till but excluding the class Bank) will inherit from the Parent class BankAccount.
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(int anum, string hn, double bal) : base(anum, hn, bal) 
        {
            Console.WriteLine("You have succesfully created a Savings Account with us. Thank you!");
            Console.WriteLine();
        }
        
        public override void Deposit(int depositamount)
        {
            double modifieddeposit = CalculateInterest(depositamount);
            Balance += modifieddeposit;
            Console.WriteLine("$" + modifieddeposit + " has been deposited into your account against a deposit of $"+depositamount);
            Console.WriteLine("Your current balance is $" + Balance);
            Console.WriteLine();
        }
        public override void Deposit(double depositamount)
        {
            double modifieddeposit = CalculateInterest(depositamount);
            Balance += modifieddeposit;
            Console.WriteLine("$" + modifieddeposit + " has been deposited into your account against a deposit of $"+depositamount);
            Console.WriteLine("Your current balance is $" + Balance);
            Console.WriteLine();
        }
        public override double CalculateInterest(double amount) //Example of dynamic polymorphism: The calculateinterest method is overridden to fit the requirements of the savingsaccount class
        {
            return amount * 1.2; //20% interest applied in savings account
        }
    }
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(int anum, string hn, int bal) : base(anum, hn, bal) 
        {
            Console.WriteLine("You have succesfully created a Checking Account with us. Thank you!");
            Console.WriteLine();
        }
        public override void Withdraw(int withdrawamount)
        {
            if (withdrawamount>Balance)
            {
                Console.WriteLine("There is insufficient balance in your account to withdraw $"+withdrawamount+"\nCurrent balance: $"+Balance);
                Console.WriteLine();
            }
            else
            {
                base.Withdraw(withdrawamount);
            }
        }
        public override double CalculateInterest(double amount) //Example of dynamic polymorphism: The calculateinterest method is overridden to fit the requirements of the checkingaccount class
        {
            return amount * 0.10; //10% interest applied
        }
    }
    public class LoanAccount : BankAccount
    {
        public LoanAccount(int anum, string hn, int bal) : base(anum, hn, bal) 
        {
            Console.WriteLine("You have succesfully created a Loan Account with us. Thank you!");
            Console.WriteLine();
        }
        public override double CalculateInterest(double amount) //Example of dynamic polymorphism: The calculateinterest method is overridden to fit the requirements of the loanaccount class
        {
            return amount * 0.20; //20% interest applied in loan account
        }
    }
    public class Bank
    /// <summary>
    /// The Bank class is an example of:
    /// 1. Association: It "has-a" bank account
    /// 2. Aggregation: It is a collection of bank account of whom the bank is the owner
    /// 3. Dependency: The bank account objects need a bank object to be created
    /// </summary>

    {
        public List<BankAccount> ListofAccounts { get; set; }
        public Bank()
        {
            ListofAccounts = new List<BankAccount>();
        }
        public void AddAccount(BankAccount Acc)
        {
            ListofAccounts.Add(Acc);
        }
        public void DepositToAccount(BankAccount Acc, int DA)
        {
            Acc.Deposit(DA);
        }
        public void WithdrawFromAccount(BankAccount Acc, int WA)
        {
            Acc.Withdraw(WA);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bank Bank1 = new Bank();
            SavingsAccount SavAcc = new SavingsAccount(82680, "Ms.Coder", 1000);
            CheckingAccount CheckAcc = new CheckingAccount(08207, "Mr.Nobody", 500);
            Bank1.AddAccount(SavAcc);
            SavAcc.DisplayAccountInfo();
            Bank1.AddAccount(CheckAcc);
            CheckAcc.DisplayAccountInfo();
            SavAcc.Deposit(100);
            CheckAcc.Withdraw(501);
            CheckAcc.Withdraw(100);

            Console.ReadKey();
        }
    }
}