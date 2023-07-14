using System;


namespace Bank_Account_Management_System
{
    public class CheckingAccount : BankAccount, ITransaction
    {
        public CheckingAccount(int anum, string hn, int bal) : base(anum, hn, bal) 
        {
            AccType = "Checking Account";
            Console.WriteLine($"Hi, {hn}, you have succesfully created a Checking Account with us. Thank you!");
            Console.WriteLine();
        }
        public void Withdraw(int withdrawamount)
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
}