using System.Linq;

namespace FibonacciRecursion
{
    public static class FibonacciOperations
    {
        public static int SequenceUpTo(int n)
            => FibonacciSequence.New.AddTill(n).Elements.Last();

        private static FibonacciSequence AddTill(this FibonacciSequence fibonacciSequence, int n)
        {
            if (fibonacciSequence.Elements.Count() - 1 == n)
                return fibonacciSequence;

            var sequence = fibonacciSequence.Elements;

            sequence.Add(sequence.Last() + sequence.SecondLast());

            return new FibonacciSequence(sequence).AddTill(n);
        }
    }
}
