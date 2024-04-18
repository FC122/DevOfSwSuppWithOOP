namespace DevOfSwSuppWithOOP.CleanCode.Refactoring.Solution2{
    class Calculator
    {
        public List<double> CalculateAverages(List<double[]> arrays)
        {
            List<double> averages = new List<double>();
            foreach (double[] array in arrays)
            {
                averages.Add(CalculateAverage(array));
            }
            return averages;
        }

        public double CalculateAverage(double[] array)
        {
            double average = 0;
            for (int i = 0; i < array.Length; i++)
            {
                average += array[i];
            }
            return average / array.Length;
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            Calculator calculator= new Calculator();
            List<double> avereages = calculator.CalculateAverages(new List<double[]>([[1,2,3,4],[1,2,3,5]]));
            avereages.ForEach(a =>
                Console.WriteLine($"{a}")
            );
        }
    }
}