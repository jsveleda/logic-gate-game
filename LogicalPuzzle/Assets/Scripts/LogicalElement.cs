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
        [SerializeField]
        protected bool output;

        private LogicOperation logicOperation;
        public event Action<bool> OnOutputChanged;

        [Header("Places from where conduits can leave (if any)")]
        public Transform outputConduitAnchor;
        [Header("Places where inputs can attach conduits (if any)")]
        public List<Transform> inputConduitAnchorList;

        private LineRenderer[] conduits;

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

#if UNITY_EDITOR
                // Gambiarra pra facilitar visualização no OnValidate
                if (logicOperation == null)
                {
                    logicOperation = LogicOperationFactory.CreateLogicOperation(operationType);
                }
#endif
                return logicOperation.Execute(Inputs);
            }
        }

        private void Awake()
        {
            SubscribeToInputChanges();
            logicOperation = LogicOperationFactory.CreateLogicOperation(operationType);
        }

        private void Start()
        {
            conduits = GetComponentsInChildren<LineRenderer>();
            UpdateOutput();
            UpdateConduits();
        }

        private void UpdateConduits()
        {
            if (conduits == null || conduits.Length == 0)
            {
                return;
            }

            for (int i = 0; i < inputs.Count; i++) 
            {
                conduits[i].material = inputs[i].output ? GlobalPrefabs.Instance.trueConduitMaterial : GlobalPrefabs.Instance.falseConduitMaterial;
            }
        }

        public List<LogicalElement> GetInputList()
        {
            return inputs;
        }

        public void ToggleOutput()
        {
            output = !Output;
            OnOutputChanged?.Invoke(output);
        }

        public void SetOutput(bool value)
        {
            output = value;
            OnOutputChanged?.Invoke(output);
        }

        /// <summary>
        /// Se inscreve em cada um dos <see cref="inputs"/> para ser notificado
        /// quando houver mudan�as em seus valores.
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
        /// Sempre que esse m�todo for chamado, atualiza <see cref="output"/> 
        /// executando a opera��o l�gica deste elemento.
        /// </summary>
        /// <remarks> Lan�a um evento <see cref="OnOutputChanged"/> com o 
        /// novo valor de <see cref="output"/> 
        /// </remarks>
        private void OnInputChanged(bool newOutput)
        {
            if (inputs == null || inputs.Count == 0)
            {
                return;
            }

            // if (newOutput == output)
            // {
            //     return;
            // }

            UpdateOutput();
        }

        protected virtual void UpdateOutput()
        {
            if (inputs.Count > 0)
            {
                output = logicOperation.Execute(Inputs);
            }

            UpdateConduits();
            OnOutputChanged?.Invoke(output);
        }
    }
}
