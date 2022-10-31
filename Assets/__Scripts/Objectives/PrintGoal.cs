using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Print Goal")]
public class PrintGoal : GoalSO
{
    //config
    [SerializeField] private string sentence;
    [SerializeField] private bool caseSensitive = true;

    //Instance 
    public static PrintGoal Instance;


    public override void Init()
    {
        base.Init();

        Instance = this;
    }
    public void CheckString(string message)
    {
        var msg = message;

        if (!caseSensitive)
        {
            msg = msg.ToLower();
            sentence = sentence.ToLower();
        }

        if (msg == sentence)
        {
            currentAmount++;
            Evaluate();

            ObjectiveEvent.onGoalUpdate.Invoke();
        }
    }
}
