using System;
using System.Collections.Generic;
using UnityEngine;

namespace Operational
{
    public abstract class LogicalElement : MonoBehaviour
    {
        private LogicOperation logicOperation;

        [SerializeField]
        private List<LogicalElement> inputs;

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

        public LogicalElement(LogicOperation logicOperation)
        {
            this.logicOperation = logicOperation;
        }

        public void SetInputs(params LogicalElement[] gates)
        {
            inputs = new List<LogicalElement>(gates);
        }
    }
}
