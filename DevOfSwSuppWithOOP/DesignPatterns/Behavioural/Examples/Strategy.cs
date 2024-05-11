namespace DevOfSwSuppWithOOP.DesignPatterns.Behavioral.Strategy{
    namespace Problem{
        public class Enemy
        {
            int x;
            int y;

            public Enemy(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void Spawn()
            {
                Console.WriteLine($"Spawn at {x} {y}");
            }
        }

        public class Game
        {
            string spawnWay;
            public Game(string spawnWay, int n)
            {
                this.spawnWay = spawnWay;
                Spawn(n);
            }

            public void SetSpawnWay(string spawnWay)
            {
                this.spawnWay = spawnWay;
            }

            public void Spawn(int n)
            {
                switch(spawnWay){
                    case "random":
                        Random random = new Random();
                        for (int i = 0; i < n; i++)
                        {
                            new Enemy(random.Next(-100, 100), random.Next(-100, 100));
                        }
                    break;

                    case "diagonal":
                        for (int i = 0; i < n; i++)
                        {
                            new Enemy(i, i);
                        }
                    break;

                    case "spot":
                        for (int i = 0; i < n; i++)
                        {
                            new Enemy(0, 0);
                        }
                    break;

                    default: throw new NotImplementedException();
                }
            }
    	}

        public static class ClientCode
        {
            public static void Run(){
                Game game = new Game("spot", 1);
                game.Spawn(10);
            }
        }
    }

    namespace Solution{
        public class Enemy
        {
            int x;
            int y;

            public Enemy(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void Spawn()
            {
                Console.WriteLine($"Spawn at {x} {y}");
            }
        }

        public interface ISpawnable
        {
            public void Spawn(int n);
        }

        public class RandomSpawn : ISpawnable
        {
            public void Spawn(int n)
            {
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    new Enemy(random.Next(-100, 100), random.Next(-100, 100));
                }
            }
        }

        public class DiagonalSpawn : ISpawnable
        {
            public void Spawn(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    new Enemy(i, i);
                }
            }
        }

        public class SpotSpawn : ISpawnable
        {
            public void Spawn(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    new Enemy(0, 0);
                }
            }
        }

        public class Game
        {
            ISpawnable spawnable;
            public Game(ISpawnable spawnable, int n)
            {
                this.spawnable = spawnable;
                Spawn(n);
            }

            public void SetSpawnWay(ISpawnable spawnable)
            {
                this.spawnable = spawnable;
            }

            public void Spawn(int n)
            {
                spawnable.Spawn(n);
            }
        }

        public static class ClientCode
        {
            public static void Run(){
                Game game = new Game(new SpotSpawn(), 1);
                game.Spawn(10);
            }
        }
    }
}