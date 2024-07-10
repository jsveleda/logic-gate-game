using UnityEditor;
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

#if UNITY_EDITOR
        [MenuItem("Tools/Update Logical Elements Visual")]
        public static void EditorUpdateVisual()
        {
            foreach (var visualController in FindObjectsOfType<LogicalElementVisualController>())
            {
                visualController.UpdateVisual();
            }
        }

        public void UpdateVisual()
        {
            logicalElement = GetComponent<LogicalElement>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            OnOutputChange(logicalElement.Output);
        }
#endif

        private void OnOutputChange(bool value)
        {
            spriteRenderer.sprite = value ? onSprite : offSprite;
            spriteRenderer.color = value ? onColor : offColor;
        }
    }
}