using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    class NonTransactionAccount: BankAccount
    {
        public NonTransactionAccount(int anum, string hn, int bal) : base(anum, hn, bal)
        {
            AccType = "Loan Account";
            Console.WriteLine($"Hi, {hn}, you have succesfully created a Non Transaction Account with us. Thank you!");
            Console.WriteLine();
        }
        public override double CalculateInterest(double amount) //Example of dynamic polymorphism: The calculateinterest method is overridden to fit the requirements of the loanaccount class
        {
            return amount * 0.30; //30% interest applied in loan account
        }

    }
}
