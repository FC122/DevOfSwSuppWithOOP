namespace DevOfSwSuppWithOOP.CleanCode.Refactoring.Solution1{
    public class VectorScaler
    {
        public void ScaleVectorByEuclideanNorm(double[] vector)
        {
            double vectorNorm = CalculateEuclideanNorm(vector);
            for (int i = 0; i < vector.Length; i++)
                vector[i] /= vectorNorm;
        }

        double CalculateEuclideanNorm(double[] vector)
        {
            double sumOfPowers = 0;
            for (int i = 0; i < vector.Length; i++)
                sumOfPowers += Math.Pow(vector[i], 2);
            return Math.Sqrt(sumOfPowers);
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            VectorScaler vectorScaler= new VectorScaler();
            double[] vector = [0, 1, 2, 3, 4];
            vectorScaler.ScaleVectorByEuclideanNorm(vector);
            foreach(double d in vector){
                Console.WriteLine(d);
            }
        }
    }
}