﻿using System;


namespace Bank_Account_Management_System
{
    public class LoanAccount : BankAccount, ITransaction
    {
        
        private double bankCharges = 8.05;
        public LoanAccount(int anum, string hn, double bal) : base(anum, hn, bal) 
        {
            AccType = "Loan Account";
            Console.WriteLine($"Hi, {hn}, you have succesfully created a Loan Account with us. Thank you!");
            Console.WriteLine();
        }
        public override double CalculateInterest(double amount) //Example of dynamic polymorphism: The calculateinterest method is overridden to fit the requirements of the loanaccount class
        {
            return amount * 0.20; //20% interest applied in loan account
        }
        public override void Deposit(int depositamount)
        {
            Transaction transaction = new Transaction(0, "");
            transaction.TransactionType = "Deposit";
            transaction.TransactionAmount = Convert.ToDouble(depositamount);
            ExecuteTransaction(transaction);
        }
        public override void Deposit(double depositamount) //Example of static polymorphism: The deposit method is overloaded with a double type arg
        {
            Transaction transaction = new Transaction(0, "");
            transaction.TransactionType = "Deposit";
            transaction.TransactionAmount = depositamount;
            ExecuteTransaction(transaction);
        }
        public override void Withdraw(int withdrawamount)
        {
            Transaction transaction = new Transaction(0, "");
            transaction.TransactionType = "Withdraw";
            transaction.TransactionAmount = withdrawamount;
            ExecuteTransaction(transaction);
        }
        public override void Withdraw(double withdrawamount) //Example of static polymorphism: The deposit method is overloaded with a double type arg
        {
            Transaction transaction = new Transaction(0, "");
            transaction.TransactionType = "Withdraw";
            transaction.TransactionAmount = withdrawamount;
            ExecuteTransaction(transaction);
        }
        public override void BankCharges()
        {
            Transaction transaction = new Transaction(0, "");
            transaction.TransactionType = "Bank Charges";
            transaction.TransactionAmount = bankCharges;
            ExecuteTransaction(transaction);
        }
        public override void InterestAccrual()
        {
            Transaction transaction = new Transaction(0, "");
            transaction.TransactionType = "Interest Accrual";
            transaction.TransactionAmount = CalculateInterest(Balance);
            ExecuteTransaction(transaction);
        }
        public void ExecuteTransaction(Transaction tr)
        {
            switch (tr.TransactionType)
            {
                case "Deposit":
                    Balance += tr.TransactionAmount;
                    ListofTransactions.Add(tr);
                    PrintTransaction(tr);
                    break;
                case "Withdraw":
                    if (Balance > tr.TransactionAmount)
                    {
                        Balance -= tr.TransactionAmount;
                        ListofTransactions.Add(tr);
                        PrintTransaction(tr);
                    }
                    else { Console.WriteLine("Insufficient funds to proceed with this request."); }
                    break;
                case "Bank Charges":
                    if (Balance > tr.TransactionAmount)
                    {
                        Balance -= tr.TransactionAmount;
                        ListofTransactions.Add(tr);
                        PrintTransaction(tr);
                    }
                    else { Console.WriteLine("Insufficient funds to proceed with this request."); }
                    break;
                case "Interest Accrual":
                    Balance += tr.TransactionAmount;
                    ListofTransactions.Add(tr);
                    PrintTransaction(tr);
                    break;
                default:
                    break;
            }
        }
        public void PrintTransaction(Transaction tr)
        {
            switch (tr.TransactionType)
            {
                case "Deposit":
                    Console.WriteLine($"${tr.TransactionAmount} has been deposited into your {AccType}");
                    break;
                case "Withdraw":
                    Console.WriteLine($"${tr.TransactionAmount} has been withdrawn from your {AccType}");
                    break;
                case "Bank Charges":
                    Console.WriteLine($"${tr.TransactionAmount} has been withdrawn from your {AccType} as bank charges");
                    break;
                case "Interest Accrual":
                    Console.WriteLine($"${tr.TransactionAmount} has been added to your {AccType} as interest");
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Your current balance is ${Balance}");
            Console.WriteLine();
        }
    }
}