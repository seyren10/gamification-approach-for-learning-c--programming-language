using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName = "Scriptable Object/Objective")]
public class ObjectiveSO : ScriptableObject
{
    public GoalSO[] goals;
    private bool objectiveComplete;

    //instance
    public static ObjectiveSO Instance;

    public void Init()
    {
        //instance
        Instance = this;
        objectiveComplete = false;

        //event: when user click the run code button
        LevelEvent.OnRunCode.AddListener(ResetGoal);

        //initialize all the goal
        foreach (var goal in goals)
        {
            goal.Init();
        }
    }

    public int GetCompletedGoalCount()
    {
        return goals.Sum(a => a.GetCurrentAmount());
    }

    public int GetTotalGoals()
    {
        return goals.Sum(a => a.requiredAmount);
    }

    private void ResetGoal()
    {
        foreach (var goal in goals)
        {
            goal.Init();
        }
    }
}
