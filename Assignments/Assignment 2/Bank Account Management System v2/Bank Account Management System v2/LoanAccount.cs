using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System_v2
{
    class LoanAccount : BankAccount, ITransaction
    {
        public LoanAccount(int anum, string hn, int bal) : base(anum, hn, bal)
        {
            AccType = "Loan Account";
            Console.WriteLine($"Hi, {hn}, you have succesfully created a Checking Account with us. Thank you!");
            Console.WriteLine();
        }
    }
}
