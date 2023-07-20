using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    class NonTransactionAccount: BankAccount
    {
        private double bankCharges = 8.05;
        public NonTransactionAccount(int anum, string hn, double bal) : base(anum, hn, bal)
        {
            AccType = "Non Transaction Account";
            Console.WriteLine($"Hi, {hn}, you have succesfully created a Non Transaction Account with us. Thank you!");
            Console.WriteLine();
        }
        public override double CalculateInterest(double amount) //Example of dynamic polymorphism: The calculateinterest method is overridden to fit the requirements of the loanaccount class
        {
            return amount * 0.30; //30% interest applied in Non Transaction Account
        }
        public override void Deposit(double amount)
        {
            Console.WriteLine($"Transaction not possible in the {AccType}");
        }
        public override void Deposit(int amount)
        {
            Console.WriteLine($"Transaction not possible in the {AccType}");
        }
        public override void Withdraw(double amount)
        {
            Console.WriteLine($"Transaction not possible in the {AccType}");
        }
        public override void Withdraw(int amount) 
        { 
            Console.WriteLine($"Transaction not possible in the {AccType}"); 
        }
        public override void BankCharges()
        {
            Transaction transaction = new Transaction(0, "");
            if (Balance>bankCharges)
            {
                Balance-=bankCharges;
                Console.WriteLine($"${bankCharges} bank charges applied");
                transaction.TransactionAmount = bankCharges;
                transaction.TransactionType = "Bank Charges";
                ListofTransactions.Add(transaction);
            }
        }
        public override void InterestAccrual()
        {
            Transaction transaction = new Transaction(0, "");
            transaction.TransactionType = "Interest Accrual";
            transaction.TransactionAmount = CalculateInterest(Balance);
            Balance += transaction.TransactionAmount;
            Console.WriteLine($"${transaction.TransactionAmount} was added to your account as interest");
            ListofTransactions.Add(transaction );
        }
    }
}
