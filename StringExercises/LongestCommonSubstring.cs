using System;

namespace StringExercises
{
    public static class LongestCommonSubstring
    {
        public static int LongestCommonSubstringWith(this string first, string second)
        {
            var firstChars = first.ToCharArray();
            var secondChars = second.ToCharArray();
            var substringMatrix = new int[firstChars.Length, secondChars.Length];
            var longest = 0;

            for(int y = 0; y < firstChars.Length; y ++)
            {
                var matchedRow = false;
                for (int x = 0; x < secondChars.Length; x++)
                {
                    var topValue = y - 1 >= 0 ? substringMatrix[y - 1, x] : 0;
                    var leftValue = x - 1 >= 0 ? substringMatrix[y, x - 1] : 0;

                    var value = matchedRow ? topValue : Math.Max(topValue, leftValue);

                    if (firstChars[y] == secondChars[x])
                    {
                        value += 1;
                        matchedRow = true;
                    }

                    if (value > longest)
                        longest = value;

                    substringMatrix[y, x] = value;
                }
            }

            return longest;
        }
    }
}
