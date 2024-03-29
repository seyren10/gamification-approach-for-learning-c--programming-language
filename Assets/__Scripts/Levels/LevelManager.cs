using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelFinishUI levelFinishUI;
    [SerializeField] private GameObject LevelFailedUI;
    [SerializeField] private StarSystem starSystem;


    public int GetStarCount()
    {
        return starSystem.GetStarCount();
    }

    private void Start()
    {
        //event: when user finish the level
        LevelEvent.OnLevelCompleted.AddListener(EvaluateStar);
        LevelEvent.OnLevelFailed.AddListener(ShowLevelFailedUI);
    }

    private void EvaluateStar()
    {
        var objective = ObjectiveSO.Instance;

        //setting the collectected points within the goal and the total required amount of goal.
        starSystem.SetCurrent(objective.GetCompletedGoalCount());
        starSystem.SetTotal(objective.GetTotalGoals());

        //prevent enemies from attack
        DisableEnemyAttack();
        ShowLevelFinishUI();
    }

    private void ShowLevelFinishUI()
    {
        levelFinishUI.Show();

        //get the total star
        levelFinishUI.Star = starSystem.GetStarCount();


        //save the total star count
        LevelInfoManager.Instance.GetLevelInfoSO.SaveGatheredStar(starSystem.GetStarCount());
        //unlocked next level
        UnlockLevel();
    }

    private static void UnlockLevel()
    {
        var levelInfoList = Resources.Load<LevelInfoListSO>(typeof(LevelInfoListSO).Name).list;
        var nextLevel = levelInfoList.IndexOf(LevelInfoManager.Instance.GetLevelInfoSO) + 1;
        if (nextLevel < levelInfoList.Count)
        {
            levelInfoList[nextLevel].SaveLevelStatus(true);
        }
    }

    private void ShowLevelFailedUI()
    {
        LevelFailedUI.SetActive(true);
    }

    private void DisableEnemyAttack()
    {
        foreach (Enemy e in FindObjectsOfType<Enemy>())
        {
            e.CanAttack = false;
        }
    }
}

[Serializable]
public class StarSystem
{
    [SerializeField] private int oneStar;
    [SerializeField] private int twoStar;
    [SerializeField] private int threeStar;

    private float total;
    private float current;

    public void SetTotal(int total)
    {
        this.total = total;
    }

    public void SetCurrent(int current)
    {
        this.current = current;
    }

    public int GetStarCount()
    {
        int accumulated = Mathf.RoundToInt((current / total) * 100f);

        Debug.Log(accumulated);

        if (accumulated >= threeStar)
        {
            return 3;
        }
        else if (accumulated >= twoStar)
        {
            return 2;
        }
        else if (accumulated >= oneStar)
        {
            return 1;
        }
        else
            return 0;
    }
}
