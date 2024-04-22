 namespace DevOfSwSuppWithOOP.DesignPatterns.Structural.Adapter{

    namespace Problem
    {
        public interface ILogger{
            void Log(string message);
        }

        public class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }

        //Pravimo se da je ovo vanjska klasa i nemožemo ju mjenjat
        public class FilerLoggerService{
            public void LogToFile(string message){
                Console.WriteLine($"Logging message to file. Message:{message}");
            }
        }

        //ConsoleLogger više ne žeilmo, kako ćemo 
        //omogućiti Klijentskom kodu da koristit servisnu klasu
        // preko ILogger sučelja

        public static class ClientCode
        {
            public static void Run()
            {
                ILogger logger = new ConsoleLogger();

                logger.Log("Hello World");
            }
        }
    }

    namespace Solution{
        public interface ILogger{
            void Log(string message);
        }

        public class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }

        //Pravimo se da je ovo vanjska klasa i nemožemo ju mjenjat
        public class FileLoggerService{
            public void LogToFile(string message){
                Console.WriteLine($"Logging message to file. Message:{message}");
            }
        }

        public class FileLoggerAdapter:ILogger{
            FileLoggerService fileLoggerService;
            public FileLoggerAdapter(){
                fileLoggerService = new FileLoggerService();
            }

            public void Log(string message){
                fileLoggerService.LogToFile(message);
            }
        }

        public static class ClientCode
        {
            public static void Run()
            {
                ILogger logger = new FileLoggerAdapter();

                logger.Log("Hello World");
            }
        }
    }
 }