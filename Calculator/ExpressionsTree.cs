using Calculator.NodeDataTypes;

namespace Calculator
{
    public class ExpressionsTree
    {
        public INode Root { get; set; }

        private class Node : INode
        {
            public INode Left { get; set; }
            public INode Right { get; set; }

            public Node(INodeData data)
            {
                Data = data;
            }

            public INodeData Data { get;  }
        }
    }

    public interface INode
    {
        public INode Left { get; set; }
        public INode Right { get; set; }
        public INodeData Data { get; }
    }
}
