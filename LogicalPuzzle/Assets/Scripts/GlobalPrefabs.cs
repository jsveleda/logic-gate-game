using UnityEngine;

public class GlobalPrefabs : MonoBehaviour
{
    public LineRenderer conduitPrefab;
    public Material trueConduitMaterial;
    public Material falseConduitMaterial;

    private static GlobalPrefabs instance;
    public static GlobalPrefabs Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GlobalPrefabs>();
            }

            return instance;
        }
    }
}
