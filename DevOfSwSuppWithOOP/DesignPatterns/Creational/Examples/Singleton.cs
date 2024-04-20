namespace DevOfSwSuppWithOOP.DesignPatterns.Creational.Singleton{
    namespace Problem{
        public class Game {
            public GameManager gm = new GameManager();
            public Game()
            {
                gm.GetConfigs();
            }
        }

        public class Character
        {
            public GameManager gm = new GameManager();
            public Character()
            {
                gm.GetCharacters();
            }
        }

        public class UI
        {
            public GameManager gm = new GameManager();
            public UI()
            {
                gm.GetUIElements();
            }
        }

        public class GameManager
        {
            public void GetConfigs()
            {
                Console.WriteLine("Configs");
            }
            public void GetUIElements()
            {
                Console.WriteLine("UI Elements");
            }
            public void GetCharacters()
            {
                Console.WriteLine("Characters");
            }
        }

        class ClientCode
        {
            public static void Run()
            {
               Game game = new Game();
               Character character = new Character();
               UI ui = new UI();
            }
        }
    }

    namespace Solution{
        public class Game
        {
            public Game()
            {
                GameManager.GetGameManager().GetConfigs();
            }
        }

        public class Character
        {
            public Character()
            {
                GameManager.GetGameManager().GetCharacters();
            }
        }
        public class UI
        {
            public GameManager gm = GameManager.GetGameManager();
            public UI()
            {
                gm.GetUIElements();
            }
        }

        public class GameManager
        {
            private static GameManager gameManager;

            public static GameManager GetGameManager()
            {
                if (gameManager == null)
                {
                    gameManager = new GameManager();
                }
                return gameManager;
            }

            public void GetConfigs()
            {
                Console.WriteLine("Configs");
            }

            public void GetUIElements()
            {
                Console.WriteLine("UI Elements");
            }

            public void GetCharacters()
            {
                Console.WriteLine("Characters");
            }
        }

        class ClientCode
        {
            public static void Run()
            {
               Game game = new Game();
               Character character = new Character();
               UI ui = new UI();
            }
        }
    }
}
