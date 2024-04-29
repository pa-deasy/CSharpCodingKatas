using System;

namespace Heaps
{
    public class MinHeap
    {
        public int[] Elements { get; }
        private int _size;

        public MinHeap(int size)
        {
            Elements = new int[size];
        }

        public int GetLeftChildIndex(int elementIndex) => elementIndex * 2 + 1;
        public int GetRightChildIndex(int elementIndex) => elementIndex * 2 + 2;
        public int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        public bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        public bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        public bool IsRoot(int elementIndex) => elementIndex == 0;

        public int GetLeftChild(int elementIndex) => Elements[GetLeftChildIndex(elementIndex)];
        public int GetRightChild(int elementIndex) => Elements[GetRightChildIndex(elementIndex)];
        public int GetParent(int elementIndex) => Elements[GetParentIndex(elementIndex)];

        public void Swap(int firstIndex, int secondIndex)
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

        public void ReCalculateDown()
        {
            var index = 0;

            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                    smallerIndex = GetRightChildIndex(index);

                if (Elements[smallerIndex] >= Elements[index])
                    break;

                Swap(index, smallerIndex);
                index = smallerIndex;
            }
        }

        public void ReCalculateUp()
        {
            var index = _size - 1;

            while (!IsRoot(index))
            {
                if (GetParent(index) < Elements[index])
                    break;

                var parentIndex = GetParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }
    }
}
