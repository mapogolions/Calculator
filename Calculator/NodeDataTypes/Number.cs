using System;

namespace Calculator.NodeDataTypes
{
    public class Number<T> : INodeData where T : struct
    {
        public Number(T value) => Value = value;
        public T Value { get;  }
        public int Precedence => byte.MaxValue;
    }
}
