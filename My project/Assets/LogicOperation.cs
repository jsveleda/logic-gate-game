using System;

namespace Operational
{
    public abstract class LogicOperation
    {
        public abstract bool Execute(params bool[] inputs);
    }

    public class OrOperation : LogicOperation
    {
        public override bool Execute(params bool[] inputs)
        {
            if (inputs.Length == 0)
            {
                throw new ArgumentException("At least one input is required for OR operation");
            }

            bool result = false;
            foreach (bool input in inputs)
            {
                result = result || input;
            }
            return result;
        }
    }

    public class AndOperation : LogicOperation
    {
        public override bool Execute(params bool[] inputs)
        {
            if (inputs.Length == 0)
            {
                throw new ArgumentException("At least one input is required for AND operation");
            }

            bool result = true;
            foreach (bool input in inputs)
            {
                result = result && input;
            }
            return result;
        }
    }

    public class NotOperation : LogicOperation
    {
        public override bool Execute(params bool[] inputs)
        {
            if (inputs.Length != 1)
            {
                throw new ArgumentException("NOT operation can only have one input");
            }

            return !inputs[0];
        }
    }

    public class XorOperation : LogicOperation
    {
        public override bool Execute(params bool[] inputs)
        {
            if (inputs.Length < 2)
            {
                throw new ArgumentException("XOR operation requires at least two inputs");
            }

            bool result = inputs[0];
            for (int i = 1; i < inputs.Length; i++)
            {
                result ^= inputs[i];
            }
            return result;
        }
    }
}
