using Operational;
using UnityEngine;

public class LampTest : MonoBehaviour
{
    [SerializeField]
    private LogicalElement and;

    private void Update()
    {
        Debug.Log(and.Output);
    }
}
