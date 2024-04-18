namespace DevOfSwSuppWithOOP.CleanCode.Renaming.Solution3{
    class RandomGenerator
    {
        private static RandomGenerator randomGenerator;
        private Random random;

        private RandomGenerator()
        {
            random = new Random();
        }
        public static RandomGenerator GetInstance()
        {
            if (randomGenerator == null)
            {
                randomGenerator = new RandomGenerator();
            }
            return randomGenerator;
        }

        public int GenerateInt()
        {
            return random.Next();
        }

        public int GenerateInt(int a, int b)
        {
            return random.Next() % (b - a + 1);
        }

        public double GenerateDouble(double a, double b)
        {
            return a + (random.NextDouble() * (b - a));
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
        Console.WriteLine(RandomGenerator.GetInstance().GenerateInt());
        }
    }
}