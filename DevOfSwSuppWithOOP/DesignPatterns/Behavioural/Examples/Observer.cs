namespace DevOfSwSuppWithOOP.DesignPatterns.Behavioral.Observer{
    namespace Problem{
        public class UserConsole 
        {
            public void ShowMessageOnConsole(string message)
            {
                Console.WriteLine($"Write to user console: {message}");
            }
        }

        public class File 
        {
            public void SaveLogToFile(string log)
            {
                Console.WriteLine($"Write log to file{log}");
            }
        }

        public class Email
        {
            public void SendMail(string mailContent)
            {
                Console.WriteLine($"Send log to mail: {mailContent}");
            }
        }

        
        public static class ClientCode
        {
            public static void Run()
            {
                UserConsole userConsole = new UserConsole();
                File file = new File();
                Email email = new Email();
                userConsole.ShowMessageOnConsole("System message");
                file.SaveLogToFile("System message");
                email.SendMail("System message");
            }
        }
    }

    namespace Solution{
        public interface ILoggable
        {
            public void Log(string message);
        }

        public class UserConsole : ILoggable
        {
            public void Log(string message)
            {
                ShowMessageOnConsole(message);
            }

            public void ShowMessageOnConsole(string message)
            {
                Console.WriteLine($"Write to user console: {message}");
            }
        }

        public class File : ILoggable
        {
            public void Log(string message)
            {
                SaveLogToFile(message);
            }

            public void SaveLogToFile(string log)
            {
                Console.WriteLine($"Write log to file{log}");
            }
        }

        public class Email : ILoggable
        {
            public void Log(string message)
            {
                SendMail(message);
            }

            public void SendMail(string mailContent)
            {
                Console.WriteLine($"Send log to mail: {mailContent}");
            }
        }

        public interface IManageable
        {
            public void Add(ILoggable loggable);
            public void Remove(ILoggable loggable);
            public void Notify(string message);
        }

        public class LogManager : IManageable
        {
            List<ILoggable> loggables = new List<ILoggable>();
            public void Add(ILoggable loggable)
            {
                loggables.Add(loggable);
            }

            public void Notify(string message)
            {
                loggables.ForEach(loggable =>
                {
                    loggable.Log(message);
                });
            }

            public void Remove(ILoggable loggable)
            {
                loggables.Remove(loggable);
            }
        }

        public static class ClientCode
        {
            public static void Run()
            {
                IManageable logginigManager = new LogManager();
                logginigManager.Add(new Email());
                logginigManager.Add(new File());
                logginigManager.Add(new UserConsole());
                logginigManager.Notify("Doslo je do errora");
            }
        }
    }
}