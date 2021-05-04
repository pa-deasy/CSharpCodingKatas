namespace LongestIncreasingSubsequence
{
    public static class NumbersArrayOperations
    {
        public static int LongestSubsequence(this int[] numbers)
        {
            var calculations = new int[numbers.Length];

            for (int index = 0; index < calculations.Length; index++)
                calculations[index] = 1;

            for (int fixedIndex = 1; fixedIndex < calculations.Length; fixedIndex++)
                for(int compareIndex = 0; compareIndex < fixedIndex; compareIndex++)
                {
                    if (numbers[fixedIndex] > numbers[compareIndex] && calculations[compareIndex] + 1 > calculations[fixedIndex])
                        calculations[fixedIndex] = calculations[compareIndex] + 1;
                }

            var longest = 1;
            foreach (int sequenceCount in calculations)
                if (sequenceCount > longest)
                    longest = sequenceCount;

            return longest;
        }
    }
}
