using System.Collections.Generic;
using System.Linq;

namespace StringExercises
{
    public static class UniqueOrdering
    {
        public static string RemoveDuplicatesAndOrder(this string input)
        {
            var chars = input.ToArray();
            var charSet = new SortedSet<char>();

            foreach(char character in chars)
            {
                charSet.Add(character);
            }

            return new string(charSet.ToArray());
        }

        private static List<char> RemoveDuplicates(this string input)
        {
            var chars = input.ToCharArray();
            var charSet = new HashSet<char>();

            foreach (char character in chars)
            {
                if (!charSet.Contains(character))
                    charSet.Add(character);
            }

            return charSet.ToList();
        }

        private static List<char> QuickSort(this List<char> chars)
        {
            if (chars.Count < 2)
                return chars;

            var charsStack = new Stack<char>(chars);
            var pivot = charsStack.Pop();
            var lessThanOrEqual = new List<char>();
            var greater = new List<char>();
            var sorted = new List<char>();

            while (charsStack.Any())
            {
                var poppedChar = charsStack.Pop();

                if (poppedChar  <= pivot)
                    lessThanOrEqual.Add(poppedChar);

                else
                    greater.Add(poppedChar);
            }

            sorted.AddRange(lessThanOrEqual.QuickSort());
            sorted.Add(pivot);
            sorted.AddRange(greater.QuickSort());

            return sorted;
        }
    }
}
