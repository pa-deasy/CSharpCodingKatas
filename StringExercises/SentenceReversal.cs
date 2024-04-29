namespace StringExercises
{
    public static class SentenceReversal
    {
        public static string ReverseSentence(this string sentence)
        {
            var words = sentence.Split(" ");
            var reversed = string.Empty;

            for(int wordsIndex = words.Length - 1; wordsIndex >= 0; wordsIndex--)
            {
                reversed += words[wordsIndex];

                if (wordsIndex != 0)
                    reversed += " ";
            }

            return reversed;
        }
    }
}
