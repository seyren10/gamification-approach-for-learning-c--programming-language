using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName = "Scriptable Object/Objective")]
public class ObjectiveSO : ScriptableObject
{
    public GoalSO[] goals;
    private bool objectiveComplete;

    public void Init()
    {
        ObjectiveEvent.onGoalCompleted.AddListener(Evaluate);
        objectiveComplete = false;

        //event: when user click the run code button
        LevelEvent.OnRunCode.AddListener(ResetGoal);

        //initialize all the goal
        foreach (var goal in goals)
        {
            goal.Init();

            //listen to the goal when its completed
            ObjectiveEvent.onGoalCompleted.AddListener(Evaluate);
        }
    }

    public void Evaluate()
    {
        if (goals.All(g => g.Completed()))
        {
            objectiveComplete = true;
        }
    }

    public bool GetObjectiveComplete()
    {
        return objectiveComplete;
    }

    private void ResetGoal()
    {
        foreach (var goal in goals)
        {
            goal.Init();
        }
    }
}
