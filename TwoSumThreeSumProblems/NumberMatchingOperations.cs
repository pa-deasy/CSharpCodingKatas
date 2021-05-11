using System.Collections.Generic;

namespace TwoSumThreeSumProblems
{
    public static class NumberMatchingOperations
    {
        public static List<int> FindPairSummingTo(this List<int> numbers, int target)
        {
            var numbersSet = new HashSet<int>();

            foreach (int currentNumber in numbers)
            {
                var diff = target - currentNumber;

                if (numbersSet.Contains(diff))
                    return new List<int> { currentNumber, diff };

                numbersSet.Add(currentNumber);
            }

            return new List<int>();
        }

        public static List<int> FindTripletSummingTo(this List<int> numbers, int target)
        {
            var numbersSet = new HashSet<int>();

            foreach(int currentNumber in numbers)
            {
                foreach(int setNumber in numbersSet)
                {
                    var diff = target - currentNumber - setNumber;
                    if (numbersSet.Contains(diff))
                        return new List<int> { currentNumber, setNumber, diff };
                }
                numbersSet.Add(currentNumber);
            }

            return new List<int>();
        }

        public static int[] FindFourSummingTo(this int[] numbers, int target)
        {
            var numbersSet = new HashSet<int>();

            for (int firstIndex = 0; firstIndex < numbers.Length; firstIndex++)
            {
                var firstNumber = numbers[firstIndex];
                for (int secondIndex = firstIndex + 1; secondIndex < numbers.Length; secondIndex++)
                {
                    var secondNumber = numbers[secondIndex];

                    foreach(int setNumber in numbersSet)
                    {

                        var diff = target - (firstNumber + secondNumber + setNumber);

                        if (diff != setNumber && numbersSet.Contains(diff))
                            return new int[] { firstNumber, secondNumber, setNumber, diff };
                    }

                    numbersSet.Add(secondNumber);
                }
            }

            return new int[0];
        }
    }
}
