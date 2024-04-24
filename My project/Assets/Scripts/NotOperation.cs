using System;

namespace Operational
{
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
}
