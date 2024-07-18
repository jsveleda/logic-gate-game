using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform levelParent;
    public TextMeshProUGUI levelTitle;
    public GameObject completionPopup;

    void Awake()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        LevelData levelData = LevelManager.Instance.GetCurrentLevel();
        levelTitle.text = "Level " + LevelManager.Instance.GetCurrentLevelName();
        Instantiate(levelData.levelPrefab, levelParent);
    }

    public void OnLevelCompleted()
    {
        LevelManager.Instance.LevelCompleted();
    }   
    
    public void ShowCompletionPopup()
    {
        completionPopup.SetActive(true);
    }

    public void OnNextLevelButton()
    {
        //completionPopup.SetActive(false);
        OnLevelCompleted();
    }
}
