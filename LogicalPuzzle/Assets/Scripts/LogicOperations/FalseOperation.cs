using System;

namespace Operational
{
    public class FalseOperation : LogicOperation
    {
        public override bool Execute(params bool[] inputs)
        {
            return false;
        }
    }
}
