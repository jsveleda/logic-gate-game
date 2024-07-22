using System.Collections;
using System.Collections.Generic;
using Operational;
using UnityEngine;

namespace Operational
{
    public class GateSlot : LogicalElement
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        protected override void Awake()
        {
            SubscribeToInputChanges();
            logicOperation = new FalseOperation();
        }

        protected override void Start()
        {
            base.Start();
        }

        public void UpdateGate(GateInfo gateInfo)
        {
            logicOperation = LogicOperationFactory.CreateLogicOperation(gateInfo.operationType);
            spriteRenderer.sprite = gateInfo.gateSprite;
            UpdateOutput();
        }
    }
}
