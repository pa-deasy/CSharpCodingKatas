using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectBinaryTreeByLevel
{
    public class BinaryTree
    {
        public Node Root { get; private set; }

        public BinaryTree(Node root)
        {
            Root = root;
        }

        public void ConnectNodesByLevel()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(Root);

            Node current = null;
            while (queue.Count > 0)
            {
                var queueCount = queue.Count;
                for (int index = 0; index < queueCount; index++)
                {
                    var previous = current;
                    current = queue.Dequeue();

                    //index > 0 because when i is 0 previous points to the last node of previous level, so skip it
                    if (index > 0)
                        previous.NextRight = current;

                    if (current.Left != null)
                        queue.Enqueue(current.Left);

                    if (current.Right != null)
                        queue.Enqueue(current.Right);
                }
                current.NextRight = null;
            }
        }
    }
}
