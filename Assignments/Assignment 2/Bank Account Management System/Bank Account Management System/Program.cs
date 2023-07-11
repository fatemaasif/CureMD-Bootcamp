﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    public interface IBankAccount
    {
        void Deposit(int amount);
        void Withdraw(int amount);
    }
    public abstract class BankAccount:IBankAccount
    {
        protected int AccNum;
        protected double Balance;
        protected string AccHolName;
        public BankAccount(int accountnumber, string holdername, int balance)
        {
            AccNum = accountnumber;
            AccHolName = holdername;
            Balance = balance;
        }
        public virtual void Deposit(int depositamount)
        {
            Balance += depositamount;
            Console.WriteLine("$"+depositamount+" has been deposited into your account");
            Console.WriteLine("Your current balance is $" + Balance);
            Console.WriteLine();
        }
        public virtual void Withdraw(int withdrawamount)
        {
            Balance -= withdrawamount;
            Console.WriteLine("$" + withdrawamount + " has been debited from your account");
            Console.WriteLine("Your current balance is $" + Balance);
            Console.WriteLine();
        }
        public void DisplayAccountInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Account Number: " + AccNum);
            Console.WriteLine("Account Holder's Name: " + AccHolName);
            Console.WriteLine("Total Balance: " + Balance);
            Console.WriteLine();
        }
    }
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(int anum, string hn, int bal) : base(anum, hn, bal) 
        {
            Console.WriteLine("You have succesfully created a Savings Account with us. Thank you!");
            Console.WriteLine();
        }
        public double interestRate=0.05;
        public override void Deposit(int depositamount)
        {
            double modifieddeposit = depositamount*(1+interestRate);
            Balance += modifieddeposit;
            Console.WriteLine("$" + modifieddeposit + " has been deposited into your account against a deposit of $"+depositamount);
            Console.WriteLine("Your current balance is $" + Balance);
            Console.WriteLine();
        }
    }
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(int anum, string hn, int bal) : base(anum, hn, bal) 
        {
            Console.WriteLine("You have succesfully created a Checking Account with us. Thank you!");
            Console.WriteLine();
        }
        public override void Withdraw(int withdrawamount)
        {
            if (withdrawamount>Balance)
            {
                Console.WriteLine("There is insufficient balance in your account to withdraw $"+withdrawamount+"\nCurrent balance: $"+Balance);
                Console.WriteLine();
            }
            else
            {
                base.Withdraw(withdrawamount);
            }
        }
    }
    public class Bank
    {
        public List<BankAccount> ListofAccounts { get; set; }
        public Bank()
        {
            ListofAccounts = new List<BankAccount>();
        }
        public void AddAccount(BankAccount Acc)
        {
            ListofAccounts.Add(Acc);
        }
        public void DepositToAccount(BankAccount Acc, int DA)
        {
            Acc.Deposit(DA);
        }
        public void WithdrawFromAccount(BankAccount Acc, int WA)
        {
            Acc.Withdraw(WA);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bank Bank1 = new Bank();
            SavingsAccount SavAcc = new SavingsAccount(82680, "Ms.Coder", 1000);
            CheckingAccount CheckAcc = new CheckingAccount(08207, "Mr.Nobody", 500);
            Bank1.AddAccount(SavAcc);
            SavAcc.DisplayAccountInfo();
            Bank1.AddAccount(CheckAcc);
            CheckAcc.DisplayAccountInfo();
            SavAcc.Deposit(100);
            CheckAcc.Withdraw(501);
            CheckAcc.Withdraw(100);

            Console.ReadKey();
        }
    }
}
