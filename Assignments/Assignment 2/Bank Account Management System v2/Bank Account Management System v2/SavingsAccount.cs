using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System_v2
{
    class SavingsAccount : BankAccount, ITransaction
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
            Console.WriteLine("$" + modifieddeposit + " has been deposited into your account against a deposit of $" + depositamount);
            Console.WriteLine("Your current balance is $" + Balance);
            Console.WriteLine();
        }
        public override void Deposit(double depositamount)
        {
            double modifieddeposit = CalculateInterest(depositamount);
            Balance += modifieddeposit;
            Console.WriteLine("$" + modifieddeposit + " has been deposited into your account against a deposit of $" + depositamount);
            Console.WriteLine("Your current balance is $" + Balance);
            Console.WriteLine();
        }
    }
}
