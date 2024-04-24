using System;

namespace Operational
{
    public abstract class LogicOperation
    {
        public abstract bool Execute(params bool[] inputs);
    }
}