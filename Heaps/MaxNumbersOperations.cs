namespace Heaps
{
    public static class MaxNumbersOperations
    {
        public static int[] HighestNumbersOf(this int[] numbers, int count)
        {
            var minHeap = new MinHeap(count);

            foreach (int number in numbers)
            {
                if (minHeap.IsFull && minHeap.Peek() >= number)
                    continue;

                if (minHeap.IsFull)
                    minHeap.Pop();

                minHeap.Add(number);
            }

            return minHeap.Elements;
        }
    }
}
