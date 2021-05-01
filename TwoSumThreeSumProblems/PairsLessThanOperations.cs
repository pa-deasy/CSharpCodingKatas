namespace TwoSumThreeSumProblems
{
    public static class PairsLessThanOperations
    {
        public static int CountOfPairsLessThan(this int[] numbers, int target)
        {
            var totalPairs = 0;

            for(int lowerIndex = 0, higerIndex = numbers.Length - 1; lowerIndex < numbers.Length;)
            {
                var total = numbers[higerIndex] + numbers[lowerIndex];

                if (lowerIndex == higerIndex)
                    break;

                if (total >= target)
                {
                    higerIndex--;
                    continue;
                }

                totalPairs += (higerIndex - lowerIndex);
                lowerIndex++;
            }

            return totalPairs;
        }
    }
}
