using System;


namespace Bank_Account_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank Bank1 = new Bank();
            BankAccount SavAcc = new SavingsAccount(82680, "Ms.Coder", 1000);
            BankAccount CheckAcc = new CheckingAccount(08207, "Mr.Nobody", 500);
            BankAccount LoanAcc = new LoanAccount(67450, "Ms.Jane", 7900);

            Bank1.AddAccount(SavAcc);
            SavAcc.DisplayAccountInfo();

            Bank1.AddAccount(CheckAcc);
            CheckAcc.DisplayAccountInfo();

            Bank1.AddAccount(LoanAcc);
            LoanAcc.DisplayAccountInfo();

            SavAcc.Deposit(100);
            CheckAcc.Withdraw(501);
            CheckAcc.Withdraw(100);
            LoanAcc.Deposit(100);
            LoanAcc.Withdraw(2000.87);
            LoanAcc.Withdraw(1000);
            LoanAcc.Deposit(5000.23);
            LoanAcc.PrintTransactionHistory();

            Console.ReadKey();
        }
    }
}