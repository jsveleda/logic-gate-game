using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    [HideInInspector]
    public bool isCompleted;

    public GameObject levelPrefab;
}