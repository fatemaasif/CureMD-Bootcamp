using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System_v2
{
    class Bank
    {
        public string BankName;
        public Dictionary<int, BankAccount> DictionaryofAccounts { get; private set; } //Dictionary of all accounts in the Bank Class
        public Bank(string BN)
        {
            BN = BankName;
            Console.WriteLine($"{BankName} bank has been created");
            DictionaryofAccounts = new Dictionary<int, BankAccount>();
        }
        public void AddAccount(BankAccount Acc)
        {
            DictionaryofAccounts.Add(Acc.AccountNumber, Acc);
        }
    }
}
