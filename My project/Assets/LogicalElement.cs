using System;
using System.Collections.Generic;
using UnityEngine;

namespace Operational
{
    public partial class LogicalElement : MonoBehaviour
    {
        [SerializeField]
        private LogicOperations operationType;
        private LogicOperation logicOperation;

        public Action<bool> OnOutputChanged;

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

        [Header("Output if no Inputs")]
        [SerializeField]
        protected bool output;

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

        public LogicalElement(LogicOperation logicOperation)
        {
            this.logicOperation = logicOperation;
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
            inputs.ForEach(input =>
            {
                input.OnOutputChanged += OnInputChanged;
            });
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
            output = logicOperation.Execute(Inputs);
            OnOutputChanged?.Invoke(newOutput);
        }
    }
}
