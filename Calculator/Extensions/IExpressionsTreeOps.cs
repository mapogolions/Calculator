using System.Collections.Generic;
using System.Linq;
using Calculator.Contracts;
using Calculator.Tokens;

namespace Calculator.Extensions
{
    public static class IExpressionsTreeOps
    {
        public static string Traverse(this IExpressionsTree @this, Traversal traversal, string sep = " ")
        {
            var nodes = traversal switch
            {
                Traversal.PreOrder => PreOrder(@this),
                Traversal.PostOrder => PostOrder(@this),
                _ => InOrder(@this)
            };
            return string.Join(sep, nodes.Select(x => x.Token));
        }

        public static IEnumerable<INode> PreOrder(this IExpressionsTree @this)
        {
            static IEnumerable<INode> Traverse(INode node, IList<INode> acc)
            {
                if (node is null) return acc;
                if (MustBeIncluded(node)) acc.Add(node);
                Traverse(node.Left, acc);
                Traverse(node.Right, acc);
                return acc;
            }
            return Traverse(@this.Root, new List<INode>());
        }

        public static IEnumerable<INode> InOrder(this IExpressionsTree @this)
        {
            static IEnumerable<INode> Traverse(INode node, IList<INode> acc)
            {
                if (node is null) return acc;
                Traverse(node.Left, acc);
                if (MustBeIncluded(node)) acc.Add(node);
                Traverse(node.Right, acc);
                return acc;
            }
            return Traverse(@this.Root, new List<INode>());
        }

        public static IEnumerable<INode> PostOrder(this IExpressionsTree @this)
        {
            static IEnumerable<INode> Traverse(INode node, IList<INode> acc)
            {
                if (node is null) return acc;
                Traverse(node.Left, acc);
                Traverse(node.Right, acc);
                if (MustBeIncluded(node)) acc.Add(node);
                return acc;
            }
            return Traverse(@this.Root, new List<INode>());
        }

        private static bool MustBeIncluded(INode node) =>
            node.Token != Operator.OpenBracket && node.Token != Operator.CloseBracket;
    }
}
