namespace DevOfSwSuppWithOOP.DesignPatterns.Behavioral.Solution1{
    public interface Channel{
        public void Add(INotifiable notifiable);
        public void Remove(INotifiable notifiable);
        public void Notify(string message);
    }

    public interface INotifiable{
        public void PushNotification(string message);
    }

    public class User : INotifiable
    {
        public void PushNotification(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Creator : Channel
    {
        List<INotifiable> notifiables;
        public Creator(){
            notifiables = new List<INotifiable>();
        }

        public void Add(INotifiable notifiable)
        {
            notifiables.Add(notifiable);
        }

        public void Notify(string message)
        {
            notifiables.ForEach(notifiable=>{
                notifiable.PushNotification(message);
            });
        }

        public void Remove(INotifiable notifiable)
        {
            notifiables.Remove(notifiable);
        }
    }

    public static class ClientCode{
        public static void Run(string[] args){
            Creator creator= new Creator();
            creator.Add(new User());
            creator.Add(new User());
            creator.Notify("Hello Subs");
        }
    }
}