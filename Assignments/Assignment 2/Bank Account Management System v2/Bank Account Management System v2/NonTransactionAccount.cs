using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System_v2
{
    class NonTransactionAccount : BankAccount
    {
        public NonTransactionAccount(int anum, string hn, int bal) : base(anum, hn, bal)
        {
            AccType = "Non Transaction Account";
            Console.WriteLine($"Hi, {hn}, you have succesfully created a Non Transaction Account with us. Thank you!");
            Console.WriteLine();
        }
    }
}
