using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName = "Scriptable Object/Objective")]
public class ObjectiveSO : ScriptableObject
{
    public GoalSO[] goals;
    private bool objectiveComplete;

    public static ObjectiveSO Instance;

    public void Init()
    {
        ObjectiveEvent.onGoalCompleted.AddListener(Evaluate);
        objectiveComplete = false;
        Instance = this;

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
}
