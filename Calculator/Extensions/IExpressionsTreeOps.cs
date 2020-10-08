using System.Collections.Generic;
using Calculator.Contracts;

namespace Calculator.Extensions
{
    public static class IExpressionsTreeOps
    {
        public static IEnumerable<INode> PreOrder(this IExpressionsTree @this)
        {
            static IEnumerable<INode> Loop(INode node, IList<INode> acc)
            {
                if (node is null) return acc;
                acc.Add(node);
                Loop(node.Left, acc);
                Loop(node.Right, acc);
                return acc;
            }
            return Loop(@this.Root, new List<INode>());
        }

        public static IEnumerable<INode> InOrder(this IExpressionsTree @this)
        {
            static IEnumerable<INode> Loop(INode node, IList<INode> acc)
            {
                if (node is null) return acc;
                Loop(node.Left, acc);
                acc.Add(node);
                Loop(node.Right, acc);
                return acc;
            }
            return Loop(@this.Root, new List<INode>());
        }

        public static IEnumerable<INode> PostOrder(this IExpressionsTree @this)
        {
            static IEnumerable<INode> Loop(INode node, IList<INode> acc)
            {
                if (node is null) return acc;
                Loop(node.Left, acc);
                Loop(node.Right, acc);
                acc.Add(node);
                return acc;
            }
            return Loop(@this.Root, new List<INode>());
        }
    }
}
