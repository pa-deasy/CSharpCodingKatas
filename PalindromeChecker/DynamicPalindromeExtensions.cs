using System.Linq;

namespace PalindromeChecker
{
    public static class DynamicPalindromeExtensions
    {
        public static string LongestPalindrome(this string word)
        {
            var wordArray = word.ToArray();
            var palindromeMatrix = new int[word.Length, word.Length];

            var longestWord = string.Empty;

            for (int y = 0; y <= word.Length - 1; y++)
            {
                for (int x = word.Length - 1; x >= 0; x--)
                {
                    if (wordArray[y] == wordArray[x])
                    {

                        var lastLength = y - 1 >= 0 && x + 1 <= word.Length - 1 ? palindromeMatrix[y - 1, x + 1] : 0;
                        var currentLength = lastLength + 1;
                        palindromeMatrix[y, x] = currentLength;

                        longestWord = currentLength > longestWord.Length ? word.Substring(y + 1 - currentLength, currentLength) : longestWord;
                    }
                }
            }

            return longestWord;
        }

        public static int PalindromeCount(this string word)
        {
            var chars = word.ToCharArray();
            var matrix = new int[chars.Length, chars.Length];
            var palindromeCount = 0;

            for (int y = 0; y < chars.Length; y++)
                for (int x = chars.Length - 1; x >= 0; x--)
                {
                    var previous = y - 1 >= 0 && x + 1 <= chars.Length - 1
                        ? matrix[y - 1, x + 1]
                        : 0;

                    var current = chars[y] == chars[x]
                        ? previous + 1
                        : 0;

                    matrix[y, x] = current;

                    var isLast = y + 1 > chars.Length - 1 || x - 1 < 0 || chars[y + 1] != chars[x - 1];

                    if (isLast)
                        palindromeCount += current / 2;
                }

            return palindromeCount;
        }
    }
}
