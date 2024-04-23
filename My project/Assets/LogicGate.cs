using System;
using System.Collections.Generic;
using UnityEngine;

namespace Operational
{
    public abstract class LogicGate : MonoBehaviour
    {
        private LogicOperation logicOperation;

        [SerializeField]
        private List<LogicGate> inputs;

        public bool[] Inputs
        {
            get
            {
                List<bool> result = new();

                inputs.ForEach(child =>
                {
                    result.Add(child.Output);
                });

                return result.ToArray();
            }
        }

        [SerializeField]
        private bool output;

        public bool Output
        {
            get
            {
                if (Inputs == null)
                {
                    return output;
                }

                return logicOperation.Execute(Inputs);
            }
        }

        public LogicGate(LogicOperation logicOperation)
        {
            this.logicOperation = logicOperation;
        }

        public void SetInputs(params LogicGate[] gates)
        {
            inputs = new List<LogicGate>(gates);
        }
    }
}
