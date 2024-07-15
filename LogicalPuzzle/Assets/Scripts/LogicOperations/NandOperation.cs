using System;

namespace Operational
{
    public class NandOperation : LogicOperation
    {
        public override bool Execute(params bool[] inputs)
        {
            if (inputs.Length == 0)
            {
                throw new ArgumentException("At least one input is required for NAND operation");
            }

            foreach (bool input in inputs)
            {
                if (input)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
