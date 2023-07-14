using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System_v2
{
    public class Transaction
    {
        public double TransactionAmount { get; set; }
        public string TransactionType;
        public BankAccount AccountObj;
        private double interestrate = 0.05; //5% default interest applied 
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
        public double CalculateInterest(double amount)
        {
            switch(AccountObj.AccType)
            {
                case "Checking Account":
                    return amount * 0.10; //10% interest applied
                case "Savings Account":
                    return amount * 1.2; //120% interest applied in savings account
                case "Loan Account":
                    return amount * 0.20; //20% interest applied in savings account
                case "Non Transaction Account":
                    return amount * 1.35; //135% interest applied in savings account
                default:
                    return amount * interestrate;
            }
        }
        public void ExecuteTransaction(decimal transactionamount, string transctiontype)
        {
            if (transctiontype == "Deposit") { AccountObj.Balance += Convert.ToDouble(transactionamount); }
            if (transctiontype == "Withdraw") { AccountObj.Balance -= Convert.ToDouble(transactionamount); }
            Transaction transaction = new Transaction(Convert.ToDouble(transactionamount), transctiontype, AccountObj);
            AccountObj.ListofTransactions.Add(transaction);
            PrintTransaction(transactionamount, transctiontype);
        }
        public void PrintTransaction(decimal transactionamount, string transctiontype)
        {
            if (transctiontype == "Deposit") { Console.WriteLine($"${transactionamount} has been deposited into your {AccountObj.AccType}"); }
            if (transctiontype == "Withdraw") { Console.WriteLine($"${transactionamount} has been withdrawn from your {AccountObj.AccType}"); }
            Console.WriteLine("Your current balance is $" + AccountObj.Balance);
            Console.WriteLine();
        }
    }
}
