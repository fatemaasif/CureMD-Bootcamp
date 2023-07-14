using System;


namespace Bank_Account_Management_System
{
    public class LoanAccount : BankAccount, ITransaction
    {
        public LoanAccount(int anum, string hn, int bal) : base(anum, hn, bal) 
        {
            AccType = "Loan Account";
            Console.WriteLine($"Hi, {hn}, you have succesfully created a Checking Account with us. Thank you!");
            Console.WriteLine();
        }
        public override double CalculateInterest(double amount) //Example of dynamic polymorphism: The calculateinterest method is overridden to fit the requirements of the loanaccount class
        {
            return amount * 0.20; //20% interest applied in loan account
        }
    }
}