using System;
using System.Collections.Generic;
using UnityEngine;

namespace Operational
{
    public class LogicalElement : MonoBehaviour
    {
        [SerializeField]
        private LogicOperationType operationType;
        [SerializeField]
        private List<LogicalElement> inputs;
        [Header("Output if no Inputs")]
        [SerializeField]
        protected bool output;

        private LogicOperation logicOperation;
        public event Action<bool> OnOutputChanged;
        
        public bool[] Inputs
        {
            get
            {
                List<bool> result = new();

                foreach (LogicalElement child in inputs)
                {
                    result.Add(child.Output);
                }

                return result.ToArray();
            }
        }

        public bool Output
        {
            get
            {
                if (inputs == null || inputs.Count == 0)
                {
                    return output;
                }

                return logicOperation.Execute(Inputs);
            }
        }

        private void Awake()
        {
            SubscribeToInputChanges();
            logicOperation = LogicOperationFactory.CreateLogicOperation(operationType);
        }

        public void ToggleOutput()
        {
            output = !Output;
            OnOutputChanged?.Invoke(output);
        }

        /// <summary>
        /// Se inscreve em cada um dos <see cref="inputs"/> para ser notificado
        /// quando houver mudanças em seus valores.
        /// </summary>
        private void SubscribeToInputChanges()
        {
            if (inputs == null || inputs.Count == 0)
            {
                return;
            }

            foreach (LogicalElement input in inputs)
            {
                input.OnOutputChanged += OnInputChanged;
            }
        }

        /// <summary>
        /// Sempre que esse método for chamado, atualiza <see cref="output"/> 
        /// executando a operação lógica deste elemento.
        /// </summary>
        /// <remarks> Lança um evento <see cref="OnOutputChanged"/> com o 
        /// novo valor de <see cref="output"/> 
        /// </remarks>
        private void OnInputChanged(bool newOutput)
        {
            if (inputs == null || inputs.Count == 0)
            {
                return;
            }

            if (newOutput == output)
            {
                return;
            }

            output = logicOperation.Execute(Inputs);
            OnOutputChanged?.Invoke(output);
        }
    }
}
