namespace DevOfSwSuppWithOOP.DesignPatterns.Structural.Proxy{
    namespace Problem{
        public interface IChatGPTService{
            public void SendPrompt(string prompt);
        }

        public class ChatGPTService: IChatGPTService{
            public void SendPrompt(string prompt){
                Console.WriteLine($"Prompt was sent: {prompt}");
            }
        }

        public static class ClientCode
        {
            public static void Run()
            {
                //ovo radi ok ali zelimo veću kontrolu nad servisom,
                //kako ćemo to postići
                IChatGPTService chatGPTService = new ChatGPTService();
                chatGPTService.SendPrompt("Hello");
            }
        }

    }

    namespace Solution{
        public interface IChatGPTService{
            public void SendPrompt(string prompt);
        }

        public class ChatGPTService: IChatGPTService{
            public void SendPrompt(string prompt){
                Console.WriteLine($"Prompt was sent: {prompt}");
            }
        }

        public class ChatGPTProxy:IChatGPTService{
            IChatGPTService chatGPTService;
            public ChatGPTProxy( IChatGPTService chatGPTService){
                this.chatGPTService = chatGPTService;
            }
            public void SendPrompt(string prompt){
                chatGPTService.SendPrompt(prompt);
            }
        }

        public static class ClientCode
        {
            public static void Run()
            {
                IChatGPTService chatGPTService = new ChatGPTProxy(new ChatGPTService());
                chatGPTService.SendPrompt("Hello");
            }
        }
    }

    namespace Examples{
        namespace VirtualProxy{
            public interface IChatGPTService{
                public void SendPrompt(string prompt);
            }

            public class ChatGPTService: IChatGPTService{
                public void SendPrompt(string prompt){
                    Console.WriteLine($"Prompt was sent: {prompt}");
                }
            }

            public class ChatGPTProxy:IChatGPTService{
                IChatGPTService chatGPTService;

                public void SendPrompt(string prompt){
                    //ljena inicializacija
                    if(chatGPTService == null){
                        chatGPTService = new ChatGPTService();
                    }
                    chatGPTService.SendPrompt(prompt);
                }
            }

            public static class ClientCode
            {
                public static void Run()
                {
                    //više se servis ne inicijalizira ovdje
                    IChatGPTService chatGPTService = new ChatGPTProxy();
                    //nego pozivom SendPrompt funkcije
                    chatGPTService.SendPrompt("Hello");
                }
            }
        }

        namespace ProtectionProxy{
            public interface IChatGPTService{
                public void SendPrompt(string prompt);
            }

            public class ChatGPTService: IChatGPTService{
                public void SendPrompt(string prompt){
                    Console.WriteLine($"Prompt was sent: {prompt}");
                }
            }

            public class ChatGPTProxy:IChatGPTService{
                IChatGPTService chatGPTService;
                public ChatGPTProxy(string username, string password){
                    if(AuthenticationService.Authenticate(username, password)){}
                        chatGPTService = new ChatGPTService();
                    }

                public void SendPrompt(string prompt){
                    chatGPTService.SendPrompt(prompt);
                }
            }

            public static class AuthenticationService{
                public static bool Authenticate(string username, string password){
                    //auth proces, ako user nije u bazi podataka vraca false inace true
                    return true;// za svrhe primjera uvijek true
                }
            }

            public static class ClientCode
            {
                public static void Run()
                {
                    IChatGPTService chatGPTService = new ChatGPTProxy("Filip","123");
                    chatGPTService.SendPrompt("Hello");
                }
            }
        }

        namespace LoggingProxy{
            public interface IChatGPTService{
                public void SendPrompt(string prompt);
            }

            public class ChatGPTService: IChatGPTService{
                public void SendPrompt(string prompt){
                    Console.WriteLine($"Prompt was sent: {prompt}");
                }
            }

            public class ChatGPTProxy:IChatGPTService{
                IChatGPTService chatGPTService;
                public ChatGPTProxy( IChatGPTService chatGPTService){
                    this.chatGPTService = chatGPTService;
                    Console.WriteLine("ChatGPTService instantiated");
                }
                public void SendPrompt(string prompt){
                    chatGPTService.SendPrompt(prompt);
                    Console.WriteLine("Prompt sent");
                }
            }

            public static class ClientCode
            {
                public static void Run()
                {
                    IChatGPTService chatGPTService = new ChatGPTProxy(new ChatGPTService());
                    chatGPTService.SendPrompt("Hello");
                }
            }
        }

        namespace CachingProxy{
             public interface IChatGPTService{
                public void SendPrompt(string prompt);
                public void LogPromptHistory();
            }

            public class ChatGPTService: IChatGPTService{
                private string lastPrompt;
                public void SendPrompt(string prompt){
                    Console.WriteLine($"Prompt was sent: {prompt}");
                    lastPrompt = prompt;
                }
                //pamti zadnj prompt a mi želimo sve promptove pamtiti
                public void LogPromptHistory(){
                    Console.WriteLine(lastPrompt);
                }
            }

            public class ChatGPTProxy:IChatGPTService{
                IChatGPTService chatGPTService;
                List<string> promtps;
                public ChatGPTProxy( IChatGPTService chatGPTService){
                    this.chatGPTService = chatGPTService;
                    promtps = new List<string>();
                }

                public void SendPrompt(string prompt){
                    chatGPTService.SendPrompt(prompt);
                    promtps.Add(prompt);
                }

                public void LogPromptHistory(){
                    Console.WriteLine("History");
                    promtps.ForEach(prompt=>{
                        Console.WriteLine(prompt);
                    });
                }
            }

            public static class ClientCode
            {
                public static void Run()
                {
                    IChatGPTService chatGPTService = new ChatGPTProxy(new ChatGPTService());
                    chatGPTService.SendPrompt("Hello");
                    chatGPTService.SendPrompt("World");
                    chatGPTService.SendPrompt("Hows the weather");
                    chatGPTService.SendPrompt("Proxy this u fn casual");
                    chatGPTService.LogPromptHistory();
                }
            }
        }
    }
}