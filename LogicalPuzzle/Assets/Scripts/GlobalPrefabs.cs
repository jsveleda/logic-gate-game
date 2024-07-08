using UnityEngine;

public class GlobalPrefabs : MonoBehaviour
{
    public LineRenderer conduitPrefab;

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
