using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionController : MonoBehaviour
{
    public LevelDatabase levelDatabase;
    public GameObject levelButtonPrefab;
    public Transform gridParent;

    private void Start()
    {
        LoadLevels();
    }

    public void Rebuild()
    {
        foreach (Transform button in gridParent.transform)
        {
            Destroy(button.gameObject);
        }
        LoadLevels();
    }

    private void LoadLevels()
    {
        for (int worldIndex = 0; worldIndex < levelDatabase.worlds.Count; worldIndex++)
        {
            for (int levelIndex = 0; levelIndex < levelDatabase.worlds[worldIndex].list.Count; levelIndex++)
            {
                LevelData levelData = levelDatabase.worlds[worldIndex].list[levelIndex];
                GameObject button = Instantiate(levelButtonPrefab, gridParent);
                button.GetComponent<LevelButton>().Setup(worldIndex, levelIndex, levelData);
            }
        }
    }
}

