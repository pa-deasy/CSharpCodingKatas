using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosestPairSummingTo
{
    public static class NumbersArrayOperations
    {
        public static Tuple<int, int> ClosestPairSummingTo(this int[] numbers, int target)
        {
            var leftNumber = numbers[0];
            var rightNumber = numbers[numbers.Length - 1];
            var closestSum = int.MaxValue;

            var sortedNumbers = numbers.QuickSort();

            for(int leftIndex = 0, rightIndex = sortedNumbers.Length - 1; leftIndex < rightIndex;)
            {
                var sum = sortedNumbers[leftIndex] + sortedNumbers[rightIndex];

                if (Math.Abs(target - sum) < Math.Abs(target - closestSum))
                {
                    closestSum = sum;
                    leftNumber = sortedNumbers[leftIndex];
                    rightNumber = sortedNumbers[rightIndex];
                }

                if (sum > target)
                    rightIndex--;

                else
                    leftIndex++;
            }

            return new Tuple<int, int>(leftNumber, rightNumber);
        }

        private static int[] QuickSort(this int [] numbers)
        {
            if (numbers.Length < 2)
                return numbers;

            var pivot = numbers.First();
            var lessThanOrEqual = new List<int>();
            var greaterThan = new List<int>();

            foreach(int number in numbers.Skip(1))
            {
                if (number > pivot)
                    greaterThan.Add(number);

                else
                    lessThanOrEqual.Add(number);
            }

            var sorted = new List<int>();

            sorted.AddRange(lessThanOrEqual.ToArray().QuickSort());
            sorted.Add(pivot);
            sorted.AddRange(greaterThan.ToArray().QuickSort());

            return sorted.ToArray();
        }
    }
}
