namespace Calculator.NodeDataTypes
{
    public class Operator : INodeData
    {
        private Operator(int precedence) => Precedence = precedence;
        public int Precedence { get; }

        public static Operator Plus = new Operator(2);
        public static Operator Minus = new Operator(2);
        public static Operator Times = new Operator(4);
        public static Operator Divide = new Operator(4);
        public static Operator OpenBracket = new Operator(1);
        public static Operator CloseBracket = new Operator(1);
    }
}
