namespace OOPBankingSystem{
    public interface IBankAccount{
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void DisplayAccountInfo();
    }
}