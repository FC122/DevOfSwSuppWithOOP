namespace DevOfSwSuppWithOOP.CleanCode.Refactoring.Solution4{
     class DrugiZadatak
    {
        public static List<char> CountUniqeCharacters(string text)
        {
            List<char> characters = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                if (CountCharacterOccurrence(text, text[i]) == 1)
                {
                    characters.Add(text[i]);
                }
            }
            return characters;
        }

        public static int CountCharacterOccurrence(string text, char character)
        {
            int count = 0;
            for (int j = 0; j < text.Length; j++)
            {
                if (character == text[j])
                {
                    count++;
                }
            }
            return count;
        }
    }
}