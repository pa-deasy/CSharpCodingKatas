namespace TwoSumThreeSumProblems
{
    public static class FirstLastMatchingOperations
    {
        public static int FirstLastMatchingInRange(int start, int end)
            => FirstLastMatchingFrom1(end) - FirstLastMatchingFrom1(start - 1);

        private static int FirstLastMatchingFrom1(int number)
        {
            if (number < 10)
                return number;

            var countMatch = number / 10;

            countMatch += 9;

            var first = number.GetFirstDigit();
            var last = number % 10;

            if (last < first)
                countMatch--;

            return countMatch;
        }

        private static int GetFirstDigit(this int number)
            => int.Parse(number.ToString().Substring(0, 1));
    }
}
