using System;

namespace Operational
{
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
