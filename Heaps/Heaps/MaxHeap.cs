using System;

namespace Heaps
{
    public class MaxHeap
    {
        public int[] Elements { get; }
        private int _size;

        public MaxHeap(int size)
        {
            Elements = new int[size];
        }

        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private int GetLeftChild(int elementIndex) => Elements[GetLeftChildIndex(elementIndex)];
        private int GetRightChild(int elementIndex) => Elements[GetRightChildIndex(elementIndex)];
        private int GetParent(int elementIndex) => Elements[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = Elements[firstIndex];
            Elements[firstIndex] = Elements[secondIndex];
            Elements[secondIndex] = temp;
        }

        public bool IsEmpty => _size == 0;

        public bool IsFull => _size == Elements.Length;

        public int Peek() 
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException();

            return Elements[0];
        }

        public int Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException();

            var result = Elements[0];
            Elements[0] = Elements[_size - 1];
            _size--;

            ReCalculateDown();

            return result;
        }

        public void Add(int element)
        {
            if (_size == Elements.Length)
                throw new IndexOutOfRangeException();

            Elements[_size] = element;
            _size++;

            ReCalculateUp();
        }

        private void ReCalculateDown()
        {
            var index = 0;

            while (HasLeftChild(index))
            {
                var biggerIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
                    biggerIndex = GetRightChildIndex(index);

                if(Elements[biggerIndex] < Elements[index])
                {
                    break;
                }

                Swap(biggerIndex, index);
                index = biggerIndex;
            }
        }

        private void ReCalculateUp()
        {
            var index = _size - 1;

            while (!IsRoot(index))
            {
                if (Elements[index] < GetParent(index))
                    break;

                var parentIndex = GetParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }
    }
}
