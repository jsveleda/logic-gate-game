using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform levelParent;
    public TextMeshProUGUI levelTitle;
    public GameObject completionPopup;

    public Drawer gatesDrawer;

    void Awake()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        LevelData levelData = LevelManager.Instance.GetCurrentLevel();
        levelTitle.text = "Level " + LevelManager.Instance.GetCurrentLevelName();
        Instantiate(levelData.levelPrefab, levelParent);

        if (levelData.useDrawer)
        {
            gatesDrawer.gameObject.SetActive(true);
            gatesDrawer.SetDrawerOptions(levelData.drawerOptions);
        }
    }

    private void OnLevelCompleted()
    {
        LevelManager.Instance.LevelCompleted();
    }   
    
    public void ShowCompletionPopup()
    {
        gatesDrawer.Close();
        completionPopup.SetActive(true);
    }

    public void OnNextLevelButton()
    {
        //completionPopup.SetActive(false);
        OnLevelCompleted();
        LevelManager.Instance.LoadNextLevel();
    }

    public void OnHomeButton()
    {
        OnLevelCompleted();
        SceneLoader.Instance.LoadScene(0);
    }
}
