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
        public BankAccount AccountObj;
        public Transaction(double transamount, string transtype, BankAccount account)
        {
            TransactionAmount = transamount;
            TransactionType = transtype;
            AccountObj = account;
        }
        public virtual void Deposit(int depositamount)
        {
            ExecuteTransaction(depositamount, "Deposit");
        }
        public virtual void Deposit(double depositamount) //Example of static polymorphism: The deposit method is overloaded with a double type arg
        {
            ExecuteTransaction(Convert.ToDecimal(depositamount), "Deposit");
        }
        public virtual void Withdraw(int withdrawamount)
        {
            ExecuteTransaction(withdrawamount, "Withdraw");
        }
        public virtual void Withdraw(double withdrawamount) //Example of static polymorphism: The deposit method is overloaded with a double type arg
        {
            ExecuteTransaction(Convert.ToDecimal(withdrawamount), "Withdraw");
        }
        public void ExecuteTransaction(decimal transactionamount, string transctiontype)
        {
            if (transctiontype == "Deposit") { AccountObj.Balance += Convert.ToDouble(transactionamount); }
            if (transctiontype == "Withdraw") { AccountObj.Balance -= Convert.ToDouble(transactionamount); }
            Transaction transaction = new Transaction(Convert.ToDouble(transactionamount), transctiontype);
            AccountObj.ListofTransactions.Add(transaction);
            PrintTransaction(transactionamount, transctiontype);
        }
        public void PrintTransaction(decimal transactionamount, string transctiontype)
        {
            if (transctiontype == "Deposit") { Console.WriteLine($"${transactionamount} has been deposited into your {AccType}"); }
            if (transctiontype == "Withdraw") { Console.WriteLine($"${transactionamount} has been withdrawn from your {AccType}"); }
            Console.WriteLine("Your current balance is $" + AccountObj.Balance);
            Console.WriteLine();
        }
        public void PrintTransactionHistory()
        {
            Console.WriteLine("Transaction History:");
            foreach (Transaction T in AccountObj.ListofTransactions)
            {
                Console.WriteLine($"{T.TransactionType}: ${T.TransactionAmount}");
            }
        }
    }
}
