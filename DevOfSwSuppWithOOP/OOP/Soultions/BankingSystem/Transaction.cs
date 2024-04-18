namespace DevOfSwSuppWithOOP.OOPBankingSystem{
    public abstract class Transaction : ITransaction{
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }

        public abstract void ExecuteTransaction();
    }

}