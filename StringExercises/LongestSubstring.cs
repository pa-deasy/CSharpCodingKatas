using System.Collections.Generic;
using System.Linq;

namespace StringExercises
{
    public static class LongestSubstring
    {
        private readonly static int UniqueCharCount = 2;

        public static string LongestSubstringForCharCountOf(this string word)
        {
            var longest = string.Empty;
            var current = new List<char>();
            var charQueue = new Queue<char>(word.ToCharArray());

            while (charQueue.Any())
            {
                var dequeuedChar = charQueue.Dequeue();

                current.Add(dequeuedChar);

                if (current.Distinct().Count() > UniqueCharCount)
                    current = current.ReduceUniqueChars();

                if (current.Count > longest.Length)
                    longest = new string(current.ToArray());
            }

            return longest;
        }

        private static List<char> ReduceUniqueChars(this List<char> current)
        {
            var currentStack = new Stack<char>(current);
            var newCurrent = new List<char>();
            var distinctChars = new HashSet<char>();

            while (current.Any())
            {
                var poppedChar = currentStack.Pop();
                distinctChars.Add(poppedChar);

                if (distinctChars.Count > UniqueCharCount)
                    break;

                newCurrent.Add(poppedChar);
            }

            newCurrent.Reverse();
            return newCurrent;
        }
    }
}
