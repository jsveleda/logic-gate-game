using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private int currentWorldIndex;
    private int currentLevelIndex;
    public LevelDatabase levelDatabase;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(int worldIndex, int levelIndex)
    {
        currentWorldIndex = worldIndex;
        currentLevelIndex = levelIndex;
        SceneManager.LoadScene(1);
    }

    public LevelData GetCurrentLevel()
    {
        return levelDatabase.worlds[currentWorldIndex].list[currentLevelIndex];
    }

    public string GetCurrentLevelName()
    {
        return $"{currentWorldIndex} - {currentLevelIndex}";
    }

    public void LevelCompleted()
    {
        GetCurrentLevel().isCompleted = true;
        // Update de dados salvos, se necessário
    }

    public void LoadNextLevel()
    {
        if (currentLevelIndex < levelDatabase.worlds[currentWorldIndex].list.Count - 1)
        {
            LoadLevel(currentWorldIndex, currentLevelIndex + 1);
        }
        else if (currentWorldIndex < levelDatabase.worlds.Count - 1)
        {
            LoadLevel(currentWorldIndex + 1, 0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ResetProgress()
    {
        foreach (ListWrapper<LevelData> world in levelDatabase.worlds)
        {
            foreach(LevelData level in world.list)
            {
                level.isCompleted = false;
            }
        }
    }
}
