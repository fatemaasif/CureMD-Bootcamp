using System;


namespace Bank_Account_Management_System
{
    /// <summary>
    /// This is an example of inheritance: The classes that follow (up till but excluding the class Bank) will inherit from the Parent class BankAccount.
    /// </summary>
    public class SavingsAccount : BankAccount, ITransaction
    {
        public SavingsAccount(int anum, string hn, double bal) : base(anum, hn, bal) 
        {
            AccType = "Savings Account";
            Console.WriteLine($"Hi, {hn}, you have succesfully created a Checking Account with us. Thank you!");
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
}