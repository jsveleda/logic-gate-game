using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelDatabase", menuName = "Level Database", order = 1)]
public class LevelDatabase : ScriptableObject
{
    [SerializeField]
    public List<ListWrapper<LevelData>> worlds;
}

[System.Serializable]
public struct ListWrapper<T>
{
    public List<T> list;
}
