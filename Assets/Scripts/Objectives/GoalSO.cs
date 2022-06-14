using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GoalSO : ScriptableObject
{
    public string description;
    public int requiredAmount;

    protected int currentAmount;
    protected bool completed;

    public virtual void Init()
    {
        currentAmount = 0;
        completed = false;
    }

    protected void Evaluate()
    {

        //check to see if the current goal is completed
        if (currentAmount >= requiredAmount)
        {
            Complete();
        }
    }

    public int GetCurrentAmount()
    {
        return currentAmount;
    }

    public bool Completed()
    {
        return completed;
    }

    protected void Complete()
    {
        completed = true;
        ObjectiveEvent.onGoalCompleted.Invoke();
    }

}
