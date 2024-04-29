using System.Linq;

namespace MissingNumber
{
    public static class NumbersArrayOperations
    {
        public static int MissingNumber(this int[] numbers)
        {
            var n = numbers.Length + 1;
            var expectedSum = (n * (n + 1)) / 2;
            var actualSum = numbers.Sum();

            return expectedSum - actualSum;
        }
    }
}
