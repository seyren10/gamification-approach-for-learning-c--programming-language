using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    private void Awake()
    {
        var sceneLoaderCount = FindObjectsOfType<SceneLoader>().Length;

        if (sceneLoaderCount > 1)
            Destroy(this.gameObject);

        else
            DontDestroyOnLoad(this.gameObject);
    }

    public void LoadInGameCodeEditor()
    {
        SceneManager.LoadScene("Code Editor");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
