using System.Collections.Generic;
using Operational;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class CircuitManager : MonoBehaviour
{
    [MenuItem("Tools/Draw Conduits")]
    public static void DrawConduits()
    {
        DestroyAllLineRenderers();
        
        LogicalElement[] logicalElements = FindObjectsOfType<LogicalElement>();

        foreach (LogicalElement logicalElement in logicalElements)
        {
            Debug.Log($"Drawing conduits for {logicalElement.name}");
            foreach (LogicalElement input in logicalElement.GetInputList())
            {
                Transform closestAnchor = FindClosestInputAnchorToAttatch(input.outputConduitAnchor, logicalElement.inputConduitAnchorList);
                if (closestAnchor != null)
                {
                    LineRenderer lr = Instantiate(GlobalPrefabs.Instance.conduitPrefab, logicalElement.transform);  

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
    }  

    private static Transform FindClosestInputAnchorToAttatch(Transform outputConduitAnchor, List<Transform> inputConduitAnchor)
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

    [MenuItem("Tools/Destroy Conduits")]
    public static void DestroyAllLineRenderers()
    {
        LineRenderer[] lineRenderers = FindObjectsOfType<LineRenderer>();
        
        foreach (LineRenderer lr in lineRenderers)
        {
            DestroyImmediate(lr.gameObject);
        }

        Debug.Log("All Line Renderers have been destroyed.");
    }
}