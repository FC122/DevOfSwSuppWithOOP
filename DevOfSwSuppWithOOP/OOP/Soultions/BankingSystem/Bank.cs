namespace OOPBankingSystem{
    public class Bank{
        private List<Customer> customers;
        private List<Transaction> transactions;
        public Bank(){
            customers = new List<Customer>();
        }   

        public void AddCustomer(Customer customer){
            customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer){
            customers.Remove(customer);
        }

        public Customer FindCustomerByAccountNumber(int accountNumber){
            return customers.Find(c => c.AccountNumber == accountNumber) ?? new Customer();
        }

        public void ExecuteTransaction(Transaction transaction){
            transaction.ExecuteTransaction();
            transactions.Add(transaction);
        }
    }
}