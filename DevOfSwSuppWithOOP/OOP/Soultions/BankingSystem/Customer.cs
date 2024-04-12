namespace OOPBankingSystem{
    public class Customer : Person, IBankAccount{
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public void Deposit(decimal amount){
            Balance += amount;
        }

        public void Withdraw(decimal amount){
            if (Balance >= amount){
                Balance -= amount;
            }else{
                Console.WriteLine("Insufficient funds.");
            }
        }

        public void DisplayAccountInfo(){
            Console.WriteLine($"Account Holder: {FirstName} {LastName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }
}