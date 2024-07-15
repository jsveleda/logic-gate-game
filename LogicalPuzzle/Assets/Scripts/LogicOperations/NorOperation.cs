using System;

namespace Operational
{
    public class NorOperation : LogicOperation
    {
        public override bool Execute(params bool[] inputs)
        {
            if (inputs.Length == 0)
            {
                throw new ArgumentException("At least one input is required for NOR operation");
            }

            bool result = false;
            foreach (bool input in inputs)
            {
                result = result || input;
            }
            return !result;
        }
    }
}
