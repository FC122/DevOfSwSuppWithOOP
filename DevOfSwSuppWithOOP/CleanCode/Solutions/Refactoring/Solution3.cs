namespace DevOfSwSuppWithOOP.CleanCode.Refactoring.Solution3{
    class Counter
    {
        public static int CountDistinctNumbers(List<int> array)
        {
            int counter = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (CountOccurrence(array, array[i]) == 1)
                {
                    counter++;
                }
            }
            return counter;
        }

        public static int CountOccurrence(List<int> array, int number)
        {
            int occurrence = 0;
            for (int j = 0; j < array.Count; j++)
            {
                if (number == array[j])
                {
                    occurrence++;
                }
            }
            return occurrence;
        }
    }
}