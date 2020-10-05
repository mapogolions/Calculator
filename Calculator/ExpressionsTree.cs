using Calculator.Types;

namespace Calculator
{
    public class ExpressionsTree
    {
        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(INodeData data)
            {
                Data = data;
            }

            public INodeData Data { get;  }
        }
    }
}
