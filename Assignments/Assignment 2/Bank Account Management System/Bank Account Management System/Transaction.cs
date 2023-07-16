using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    public class Transaction
    {
        public double TransactionAmount { get; set; }
        public string TransactionType;
        public Transaction(double transamount, string transtype)
        {
            TransactionAmount = transamount;
            TransactionType = transtype;
        }
    }
}
