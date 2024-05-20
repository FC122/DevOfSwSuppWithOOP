namespace DevOfSwSuppWithOOP.DesignPatterns.Behavioral.Solution3{
    public abstract class Handler
    {
        public Handler NextHandler;

        public void SetNextHandler(Handler NextHandler)
        {
            this.NextHandler = NextHandler;
        }
        public abstract void DispatchNote(long requestedAmount);
    }

    public class HundredHandler : Handler
    {
        public override void DispatchNote(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 100;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Hundred notes are dispatched by HundredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Hundred note is dispatched by HundredHandler");
                }
            }
        }
    }

    public class TwoHundredHandler : Handler
    {
        public override void DispatchNote(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 200;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Hundred notes are dispatched by TwoHundredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Hundred note is dispatched by TwoHundredHandler");
                }
            }
            long pendingAmountToBeProcessed = requestedAmount % 200;
            if (pendingAmountToBeProcessed > 0)
            {
                NextHandler.DispatchNote(pendingAmountToBeProcessed);
            }
        }
    }

    public class FiveHundredHandler : Handler
    {
        public override void DispatchNote(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 500;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred notes are dispatched by FiveHundredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred note is dispatched by FiveHundredHandler");
                }
            }
            long pendingAmountToBeProcessed = requestedAmount % 500;
            if (pendingAmountToBeProcessed > 0)
            {
                NextHandler.DispatchNote(pendingAmountToBeProcessed);
            }
        }
    }

    public static class ClientCode{
        public static void Run(){
            FiveHundredHandler fiveHundredHandler = new FiveHundredHandler();
            TwoHundredHandler twoHundredHandler = new TwoHundredHandler();
            HundredHandler hundredHandler = new HundredHandler();
            
            fiveHundredHandler.SetNextHandler(twoHundredHandler);
            twoHundredHandler.SetNextHandler(hundredHandler);

            fiveHundredHandler.DispatchNote(200);
        }
    }
}