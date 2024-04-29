using System.Collections.Generic;
using System.Linq;

namespace FibonacciRecursion
{
    public static class EnumerableExtensions
    {
        public static T SecondLast<T>(this IEnumerable<T> enumerable)
            => enumerable.ToArray()[enumerable.Count() - 2];
    }
}
