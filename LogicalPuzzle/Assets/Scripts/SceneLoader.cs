using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;
    public static SceneLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneLoader>();
            }

            return instance;
        }
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
