namespace LargestContiguousSum
{
    public static class NumbersArrayOperations
    {
        public static int LargestContiguousSum(this int[] numbers)
        {
            var currentSum = int.MinValue;
            var largestSum = int.MinValue;
            
            foreach(int number in numbers)
            {
                if (number > currentSum && currentSum < 0)
                    currentSum = number;
                else
                    currentSum += number;

                if (currentSum > largestSum)
                    largestSum = currentSum;
            }

            return largestSum;
        }
    }
}
