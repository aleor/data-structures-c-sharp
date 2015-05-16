using System;

namespace DataStructures
{
    
    class NodeChain
    {
        
        public void Execute()
        {
            
            var firstNode = new Node() {Value = 3};
            var middleNode = new Node() {Value = 5};
            var lastNode = new Node() {Value = 7};

            firstNode.Next = middleNode;
            middleNode.Next = lastNode;

            PrintNodeChain(firstNode);
        }

        private void PrintNodeChain(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
