using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System_v2
{
    interface ITransaction
    {
        void Deposit(int depamount);
        void Deposit(double depamount);
        void Withdraw(int withdrawamount);
        void Withdraw(double withdrawamount);
    }
}
