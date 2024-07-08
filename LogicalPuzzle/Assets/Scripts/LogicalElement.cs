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
            DrawConduits();
        }

        #region Conduit
        private void DrawConduits()
        {
            foreach (LogicalElement input in inputs)
            {
                Transform closestAnchor = FindClosestInputAnchorToAttatch(input.outputConduitAnchor, inputConduitAnchorList);
                if (closestAnchor != null)
                {
                    LineRenderer lr = Instantiate(GlobalPrefabs.Instance.conduitPrefab, transform);
                    lr.positionCount = 4;                   
                        
                    lr.SetPosition(0, input.outputConduitAnchor.position);
                    Vector3 foldPoint1 = new Vector3(input.outputConduitAnchor.position.x,
                                                     (input.outputConduitAnchor.position.y + closestAnchor.position.y) / 2,
                                                     0);
                    lr.SetPosition(1, foldPoint1);
                    Vector3 foldPoint2 = new Vector3(closestAnchor.position.x,
                                                     (input.outputConduitAnchor.position.y + closestAnchor.position.y) / 2,
                                                     0);
                    lr.SetPosition(2, foldPoint2);
                    lr.SetPosition(3, closestAnchor.position);
                }
            }
        }

        private Transform FindClosestInputAnchorToAttatch(Transform outputConduitAnchor, List<Transform> inputConduitAnchor)
        {
            float minDistance = float.MaxValue;
            Transform closestAnchor = null;

            foreach (Transform inputAnchor in inputConduitAnchor)
            {
                float distance = Vector3.Distance(outputConduitAnchor.position, inputAnchor.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestAnchor = inputAnchor;
                }
            }

            return closestAnchor;
        }

        #endregion

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
