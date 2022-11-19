using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scriptable Object/LevelInfo")]
public class LevelInfoSO : ScriptableObject
{
    public string levelName;
    public string levelNameInfo;
    public LevelType levelType;
    private bool isUnlocked;
    private int gatheredStar;

    public int LoadGatheredStar()
    {
        if (PlayerPrefs.HasKey(levelName + "star"))
            return PlayerPrefs.GetInt(levelName + "star");
        else
            return 0;
    }

    public bool LoadLevelStatus()
    {
        if (PlayerPrefs.HasKey(levelName + "status"))
            if (PlayerPrefs.GetInt(levelName + "status") == 1)
                return true;

        return false;
    }

    public void SaveGatheredStar(int starCount)
    {
        PlayerPrefs.SetInt(levelName + "star", starCount);
    }

    public void SaveLevelStatus(bool isUnlocked)
    {
        if (isUnlocked)
            PlayerPrefs.SetInt(levelName + "status", 1);
        else
            PlayerPrefs.SetInt(levelName + "status", 0);
    }

}



public enum LevelType
{
    BasicPrinting,
    Variables,
    DataTypes,
    Operators,
    Condition,
    UserInput
}
