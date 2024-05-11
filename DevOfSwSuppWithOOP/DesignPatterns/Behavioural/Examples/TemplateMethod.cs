namespace DevOfSwSuppWithOOP.DesignPatterns.Behavioral.TemplateMethod{
    namespace Problem{
        public class Game
        {
            public Game()
            {
                Console.WriteLine("Start Game");
                Console.WriteLine("Spawn Enemy");
                Console.WriteLine("Spawn a Player");
                Console.WriteLine("End Game");
            }
        }
        public class GameManager
        {
            Game game;
            public GameManager(Game game)
            {
                this.game = game;
            }
        }

        public static class ClientCode
        {
            public static void Run(){
                GameManager gameManager = new GameManager(new Game());
            }
        }
    }

    namespace Solution{
         public abstract class Game
        {
            public void Play()
            {
                StartGame();
                SpawnEnemies();
                SpawnAPlayer();
                EndGame();
            }
            public void StartGame()
            {
                Console.WriteLine("Start Game");
            }
            public abstract void SpawnEnemies();
            public abstract void SpawnAPlayer();
            public virtual void EndGame()
            {
                Console.WriteLine("End Game");
            }
        }

        public class Multiplayer : Game
        {
            public override void SpawnAPlayer()
            {
                Console.WriteLine("Spawn a bunch of Players");
            }

            public override void SpawnEnemies()
            {
                Console.WriteLine("Spawn a bunch of Enemies");
            }
        }

        public class ZombieGame : Game
        {
            public override void SpawnAPlayer()
            {
                Console.WriteLine("Spawn a Player");
            }

            public override void SpawnEnemies()
            {
                Console.WriteLine("Spawn 5 Zombies");
            }
        }

        public class GameManager
        {
            Game game;
            public GameManager(Game game)
            {
                this.game = game;
                game.Play();
            }
        }

        public static class ClientCode
        {
            public static void Run(){
               GameManager gameManager = new GameManager(new Multiplayer());
            }
        }
    }
}