using System.Collections;
using System.Collections.Generic;
using Operational;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewLevelData", menuName = "Level Data", order = 50)]
public class LevelData : ScriptableObject
{
    public bool isCompleted;

    public GameObject levelPrefab;

    public bool useDrawer;
#if UNITY_EDITOR
    [ShowIf("useDrawer")]
#endif
    public List<GateInfo> drawerOptions;
}