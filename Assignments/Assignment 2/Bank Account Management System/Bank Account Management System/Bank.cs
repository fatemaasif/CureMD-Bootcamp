using System.Collections.Generic;


namespace Bank_Account_Management_System
{
    public class Bank
    /// <summary>
    /// The Bank class is an example of:
    /// 1. Association: It "has-a" bank account
    /// 2. Aggregation: It is a collection of bank account of whom the bank is the owner
    /// 3. Dependency: The bank account objects need a bank object to be created
    /// </summary>

    {
        public Dictionary<int,BankAccount> DictionaryofAccounts { get; private set; } //Dictionary of all accounts in the Bank Class
        public Bank()
        {
            DictionaryofAccounts = new Dictionary<int, BankAccount>();
        }
        public void AddAccount(BankAccount Acc)
        {
            DictionaryofAccounts.Add(Acc.AccountNumber, Acc);
        }
    }
}