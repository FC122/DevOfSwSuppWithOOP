namespace OOPBankingSystem{
    public static class ClientCode{
        public static void Run(){
            Bank bank = new();

            Customer customer1 = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                AccountNumber = 123456,
                Balance = 1000
            };

            Customer customer2 = new Customer
            {
                FirstName = "Jane",
                LastName = "Smith",
                AccountNumber = 654321,
                Balance = 2000
            };

            bank.AddCustomer(customer1);
            bank.AddCustomer(customer2);

            customer1.DisplayAccountInfo();
            customer2.DisplayAccountInfo();

            TransactionTransfer transfer = new()
            {
                Amount = 500,
                SourceAccountNumber = customer1.AccountNumber,
                DestinationAccountNumber = customer2.AccountNumber
            };

            bank.ExecuteTransaction(transfer);

            customer1.DisplayAccountInfo();
            customer2.DisplayAccountInfo();
        }
    }
}