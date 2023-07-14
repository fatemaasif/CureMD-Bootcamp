using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System_v2
{
    class CheckingAccount: BankAccount, ITransaction
    {
        public CheckingAccount(int anum, string hn, int bal) : base(anum, hn, bal)
        {
            AccType = "Checking Account";
            Console.WriteLine($"Hi, {hn}, you have succesfully created a Checking Account with us. Thank you!");
            Console.WriteLine();
        }
        public override void Withdraw(int withdrawamount)
        {
            if (withdrawamount > Balance)
            {
                Console.WriteLine("There is insufficient balance in your account to withdraw $" + withdrawamount + "\nCurrent balance: $" + Balance);
                Console.WriteLine();
            }
            else
            {
                base.Withdraw(withdrawamount);
            }
        }

    }
}
