using Operational;
using UnityEngine;

public class LampTest : MonoBehaviour
{
    [SerializeField]
    private LogicalElement and;

    private void Awake()
    {
        and.OnOutputChanged += OnPiscou;
    }

    private void OnPiscou(bool _)
    {
        gameObject.SetActive(and.Output);
    }
}
