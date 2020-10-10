using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Contracts;
using Calculator.Tokens;

namespace Calculator.Extensions
{
    public static class IExpressionsTreeOps
    {
        public static double Reduce(this IExpressionsTree @this)
        {
            static double Iter(INode node)
            {
                if (node is null) return 0;
                if (node.Token == Operator.OpenBracket) return Iter(node.Right);
                if (node.Token is Number<int> num) return num.Value;
                if (node.Token is Number<double> floatingPoint) return floatingPoint.Value;
                if (node.Token is BinaryOperator binaryOperator)
                {
                    return binaryOperator.Sign switch
                    {
                        '+' => Iter(node.Left) + Iter(node.Right),
                        '-' => Iter(node.Left) - Iter(node.Right),
                        '*' => Iter(node.Left) * Iter(node.Right),
                        '/' => Iter(node.Left) / Iter(node.Right),
                        '^' => Math.Pow(Iter(node.Left), Iter(node.Right)),
                        _ => throw new InvalidOperationException()
                    };
                }
                if (node.Token is UnaryOperator unaryOperator)
                {
                    return unaryOperator.Sign switch
                    {
                        '+' => Iter(node.Right),
                        '-' => - Iter(node.Right),
                        _ => throw new InvalidOperationException()
                    };
                }
                throw new InvalidOperationException();
            }
            return Iter(@this.Root);
        }

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
            static IEnumerable<INode> Iter(INode node, IList<INode> acc)
            {
                if (node is null) return acc;
                if (MustBeIncluded(node)) acc.Add(node);
                Iter(node.Left, acc);
                Iter(node.Right, acc);
                return acc;
            }
            return Iter(@this.Root, new List<INode>());
        }

        public static IEnumerable<INode> InOrder(this IExpressionsTree @this)
        {
            static IEnumerable<INode> Iter(INode node, IList<INode> acc)
            {
                if (node is null) return acc;
                Iter(node.Left, acc);
                if (MustBeIncluded(node)) acc.Add(node);
                Iter(node.Right, acc);
                return acc;
            }
            return Iter(@this.Root, new List<INode>());
        }

        public static IEnumerable<INode> PostOrder(this IExpressionsTree @this)
        {
            static IEnumerable<INode> Iter(INode node, IList<INode> acc)
            {
                if (node is null) return acc;
                Iter(node.Left, acc);
                Iter(node.Right, acc);
                if (MustBeIncluded(node)) acc.Add(node);
                return acc;
            }
            return Iter(@this.Root, new List<INode>());
        }

        private static bool MustBeIncluded(INode node) =>
            node.Token != Operator.OpenBracket && node.Token != Operator.CloseBracket;
    }
}
