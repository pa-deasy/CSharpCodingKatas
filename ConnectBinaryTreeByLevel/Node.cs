using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectBinaryTreeByLevel
{
    public class Node
    {
        public int Value { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }
        public Node NextRight { get; set; }

        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
