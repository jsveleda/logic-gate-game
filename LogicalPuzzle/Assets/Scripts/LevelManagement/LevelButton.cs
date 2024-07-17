using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private int worldIndex;
    private int levelIndex;
    private LevelData levelData;

    [SerializeField]
    private TextMeshProUGUI levelNameText;
    [SerializeField]
    private GameObject levelCheckmark;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void Setup(int world, int level, LevelData data)
    {
        worldIndex = world;
        levelIndex = level;
        levelData = data;
        
        levelNameText.text = $"{world} - {level}";
        levelCheckmark.SetActive(data.isCompleted);
    }

    public void OnClick()
    {
        LevelManager.Instance.LoadLevel(worldIndex, levelIndex);
    }
}

