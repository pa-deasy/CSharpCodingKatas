using System;
using System.Collections.Generic;
using System.Text;

namespace PalindromeChecker
{
    public static class EfficientPalindromeExtensions
    {
        public static int EfficientCountOfPalindromes(this string input)
        {
            var inputChars = input.ToCharArray();

            // create empty 2-D matrix that counts
            // all palindrome substring. dp[i][j]
            // stores counts of palindromic
            // substrings in st[i..j]

            int[][] palindromeCountMatrix
                = RectangularArrays.ReturnRectangularIntArray(
                    input.Length, input.Length);

            // P[i][j] = true if substring str[i..j]
            // is palindrome, else false

            bool[][] palindromeCheckMatrix
                = RectangularArrays.ReturnRectangularBoolArray(
                    input.Length, input.Length);

            // palindrome of single length
            for (int index = 0; index < input.Length; index++)
                palindromeCheckMatrix[index][index] = true;

            // palindrome of length 2
            for (int index = 0; index < input.Length - 1; index++)
            {
                if (inputChars[index] == inputChars[index + 1])
                {
                    palindromeCheckMatrix[index][index + 1] = true;
                    palindromeCountMatrix[index][index + 1] = 1;
                }
            }

            // Palindromes of length more then 2.
            // This loop is similar to Matrix Chain
            // Multiplication. We start with a gap
            // of length 2 and fill DP table in a
            // way that gap between starting and
            // ending indexes increases one by one
            // by outer loop.
            for (int gap = 2; gap < input.Length; gap++)
            {
                // Pick starting point for current gap
                for (int i = 0; i < input.Length - gap; i++)
                {
                    // Set ending point
                    int j = gap + i;

                    // If current string is palindrome
                    if (inputChars[i] == inputChars[j] && palindromeCheckMatrix[i + 1][j - 1])
                    {
                        palindromeCheckMatrix[i][j] = true;
                    }

                    // Add current palindrome substring
                    // ( + 1) and rest palindrome substring
                    // (dp[i][j-1] + dp[i+1][j]) remove common
                    // palindrome substrings (- dp[i+1][j-1])
                    if (palindromeCheckMatrix[i][j] == true)
                    {
                        palindromeCountMatrix[i][j] = palindromeCountMatrix[i][j - 1] + palindromeCountMatrix[i + 1][j]
                                   + 1 - palindromeCountMatrix[i + 1][j - 1];
                    }
                    else
                    {
                        palindromeCountMatrix[i][j] = palindromeCountMatrix[i][j - 1] + palindromeCountMatrix[i + 1][j]
                                   - palindromeCountMatrix[i + 1][j - 1];
                    }
                }
            }

            // return total palindromic substrings
            return palindromeCountMatrix[0][input.Length - 1];
        }
    }

    public static class RectangularArrays
    {
        public static int[][] ReturnRectangularIntArray(
            int size1, int size2)
        {
            int[][] newArray = new int[size1][];
            for (int array1 = 0; array1 < size1; array1++)
            {
                newArray[array1] = new int[size2];
            }

            return newArray;
        }

        public static bool[][] ReturnRectangularBoolArray(
            int size1, int size2)
        {
            bool[][] newArray = new bool[size1][];
            for (int array1 = 0; array1 < size1; array1++)
            {
                newArray[array1] = new bool[size2];
            }

            return newArray;
        }
    }
}
