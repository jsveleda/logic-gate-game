using System;

namespace Operational
{
    public class LogicGate
    {
        private LogicOperation logicOperation;

        private bool[] inputs;

        public bool Output
        {
            get
            {
                if (inputs == null)
                {
                    throw new InvalidOperationException("Inputs not set");
                }

                return logicOperation.Execute(inputs);
            }
        }

        public LogicGate(LogicOperation logicOperation)
        {

            this.logicOperation = logicOperation;
        }
    }
}
