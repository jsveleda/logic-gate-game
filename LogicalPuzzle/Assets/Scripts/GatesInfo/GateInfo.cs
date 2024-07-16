using UnityEngine;
using TMPro;
using Operational;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace Operational
{
    [CreateAssetMenu(fileName = "NewGateInfo", menuName = "Gate Info", order = 51)]
    public class GateInfo : ScriptableObject
    {
        public LogicOperationType operationType;
        public Sprite gateSprite;
        public string gateName;
        [TextArea(10,30)]
        public string gateDescription;
    }
}