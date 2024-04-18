namespace DevOfSwSuppWithOOP.CleanCode.Renaming.Solution1{
    enum Shape { Circle, Square }
    class Cake
    {
        public int LayersCount { get; private set; }
        public Shape Shape { get; private set; }
        public bool HasFrosting { get; private set; }
        public Cake(int layersCount, Shape shape, bool hasFrosting)
        {
            LayersCount = layersCount;
            Shape = shape;
            HasFrosting = hasFrosting;
        }
    }

    class CakeFactory
    {
        public static Cake? Create(string type)
        {
            switch (type)
            {
                case "standard": return new Cake(2, Shape.Square, false);
                case "fancy": return new Cake(4, Shape.Circle, false);
                case "wedding": return new Cake(6, Shape.Circle, true);
                default: return null;
            }
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            Cake cake = CakeFactory.Create("standard");
            Console.WriteLine($"{cake.Shape}, {cake.LayersCount}, {cake.HasFrosting}");
        }
    }
}