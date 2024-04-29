using System.Collections.Generic;

namespace FibonacciRecursion
{
    public class FibonacciSequence
    {
        public IList<int> Elements { get; private set; }

        public FibonacciSequence(IList<int> elements)
        {
            Elements = elements;
        }

        public static FibonacciSequence New =>
            new FibonacciSequence(new List<int> { 0, 1 });
    }
}
