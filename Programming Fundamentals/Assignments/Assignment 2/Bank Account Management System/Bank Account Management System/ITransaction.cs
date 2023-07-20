namespace Bank_Account_Management_System
{
    public interface ITransaction 
        ///This is an interface with functions that all accounts must have in order to fit the characteristics of a bank account
    {
        void ExecuteTransaction(Transaction transaction);
        void PrintTransaction(Transaction transaction);
    }
}