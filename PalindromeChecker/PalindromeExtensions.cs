using System;
using System.Collections.Generic;
using System.Linq;

namespace PalindromeChecker
{
    public static class PalindromeExtensions
    {
        private static readonly int MinPalindromeLength = 2;

        public static int CountOfPalindromes(this string input)
        {
            var substringsToVerify = new List<string>();

            while(input.Length >= MinPalindromeLength)
            {
                substringsToVerify.Add(input);
                input = input.Substring(1);
            }

            return substringsToVerify.Select(s => s.CountOfPalindromesStartingAt()).Sum();
        }

        public static int CountOfPalindromesStartingAt(this string input)
            => input.ToCharArray()
            .Aggregate(CheckerState.New, (checkerState, nextChar) => 
                new CheckerState(
                    checkerState.CurrentString + nextChar.ToString(),
                    (checkerState.CurrentString + nextChar.ToString()).IsAPalindrome() 
                        ? checkerState.CurrentPalindromes + 1 : checkerState.CurrentPalindromes))
            .CurrentPalindromes;

        public static bool IsAPalindrome(this string input)
            => new string(input.ToCharArray().Reverse().ToArray()) == input &&
                    input.Length >= MinPalindromeLength;
    }

    public class CheckerState
    {
        public string CurrentString { get; private set; }
        public int CurrentPalindromes { get; private set; }

        public CheckerState(string currentString, int currentPalinedromes)
        {
            CurrentString = currentString;
            CurrentPalindromes = currentPalinedromes;
        }

        public static CheckerState New => new CheckerState(string.Empty, 0);
    }
}
