using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadInGameCodeEditor()
    {
        SceneManager.LoadScene("Code Editor");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadNextScene()
    {
        InitializeEvents();

        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void ReloadScene()
    {
        InitializeEvents();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //IMPORTANT: you need to create new class of class that derives from BaseEvent class
    //this is to remove all the listeners from devired classes of Base event
    private void InitializeEvents()
    {
        LevelEvent.Init();
        ObjectiveEvent.Init();
    }
}
