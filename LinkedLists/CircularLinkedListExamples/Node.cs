using System;
using System.Collections.Generic;
using System.Text;

namespace CircularLinkedListExamples
{
    public class Node
    {
        public int Value { get; private set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
