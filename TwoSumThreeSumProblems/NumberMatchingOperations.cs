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
    }
}
