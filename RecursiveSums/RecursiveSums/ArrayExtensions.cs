using System.Collections.Generic;
using System.Linq;

namespace RecursiveSums
{
    public static class ArrayExtensions
    {
        public static int Sum(this int[] numbers)
        {
            if (!numbers.Any())
                return 0;

            var numbersStack = new Stack<int>(numbers);
            var popped = numbersStack.Pop();

            return popped + numbersStack.ToArray().Sum();
        }

        public static int Count<T>(this T[] array)
        {
            if (!array.Any())
                return 0;

            var stack = new Stack<T>(array);
            stack.Pop();

            return 1 + stack.ToArray().Count();
        }

        public static int Max(this int[] numbers)
        {
            if (!numbers.Any())
                return 0;

            var numbersStack = new Stack<int>(numbers);
            var popped = numbersStack.Pop();

            var subsequentMax = numbersStack.ToArray().Max();
            return popped > subsequentMax ? popped : subsequentMax;
        }
    }
}
