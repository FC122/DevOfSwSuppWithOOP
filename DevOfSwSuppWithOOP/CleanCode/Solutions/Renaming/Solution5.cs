namespace DevOfSwSuppWithOOP.CleanCode.Renaming.Solution5{
    public class Location
    {
        public DateTime CreatedAt { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Location(double latitude, double longitude)
        {
            // Constructor implementation
        }
    }

    public class PathManager
    {
        private List<Location> pathPoints; 

        public PathManager()
        {
            pathPoints = new List<Location>();
        }

        public void AddPathPoint(Location point)
        {
            pathPoints.Add(point);
        }

        public void RemovePathPoint(Location point)
        {
            pathPoints.Remove(point);
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            PathManager pathManager = new PathManager();

            pathManager.AddPathPoint(new Location(0,0));
            pathManager.AddPathPoint(new Location(1,1));
        }
    }
}