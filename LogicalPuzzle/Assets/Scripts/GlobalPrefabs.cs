using System.Collections.Generic;
using Operational;
using UnityEngine;

public class GlobalPrefabs : MonoBehaviour
{
    public LineRenderer conduitPrefab;
    public Material trueConduitMaterial;
    public Material falseConduitMaterial;

    public List<GateInfo> gateInfoList;

    private static GlobalPrefabs instance;
    public static GlobalPrefabs Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GlobalPrefabs>();

                if (instance == null)
                {
                    GameObject singleton = new GameObject(typeof(GlobalPrefabs).ToString());
                    instance = singleton.AddComponent<GlobalPrefabs>();
                    DontDestroyOnLoad(singleton);
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
