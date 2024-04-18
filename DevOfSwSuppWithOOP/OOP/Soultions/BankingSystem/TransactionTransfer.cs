namespace DevOfSwSuppWithOOP.OOPBankingSystem{
    public class TransactionTransfer : Transaction{
        public int SourceAccountNumber { get; set; }
        public int DestinationAccountNumber { get; set; }

        public override void ExecuteTransaction(){
            Console.WriteLine($"Transfer {Amount} from account {SourceAccountNumber} to account {DestinationAccountNumber}");
        }
    }
}