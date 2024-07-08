using UnityEngine;

namespace Operational
{
    public class LogicalElementVisualController : MonoBehaviour
    {
        [Header("False Output Sprite")]
        [SerializeField]
        private Sprite offSprite;
        [SerializeField]
        private Color offColor = Color.gray;
        [Header("True Output Sprite")]
        [SerializeField]
        private Sprite onSprite;
        [SerializeField]
        private Color onColor = Color.white;

        private LogicalElement logicalElement;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            logicalElement = GetComponent<LogicalElement>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            logicalElement.OnOutputChanged += OnOutputChange;
        }

        private void Start()
        {
            OnOutputChange(logicalElement.Output);
        }

        private void OnValidate()
        {
            logicalElement = GetComponent<LogicalElement>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            OnOutputChange(false);
        }

        private void OnOutputChange(bool value)
        {
            spriteRenderer.sprite = value ? onSprite : offSprite;
            spriteRenderer.color = value ? onColor : offColor;
        }
    }
}