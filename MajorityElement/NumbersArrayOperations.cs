using System;
using System.Collections.Generic;

namespace MajorityElement
{
    public static class NumbersArrayOperations
    {
        public static int MajorityElement(this int[] numbers)
        {
            var elements = new Dictionary<int, int>();
            int? maxElement = null;

            foreach (int number in numbers)
            {
                if (elements.ContainsKey(number))
                    elements[number] += 1;

                else
                    elements.Add(number, 1);

                if (maxElement == null || elements[maxElement.Value] < elements[number])
                    maxElement = number;
            }

            if (elements[maxElement.Value] > numbers.Length / 2)
            {
                Console.WriteLine($"Majority element is {maxElement}");
                return maxElement.Value;
            }

            Console.WriteLine($"No majority element");
            return 0;
        }
    }
}
