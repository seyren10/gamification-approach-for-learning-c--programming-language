using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Enemy Kill Goal")]
public class EnemyKill : GoalSO
{
    public override void Init()
    {
        base.Init();

        //Event: when enemy killed
        ObjectiveEvent.onEnemyKill.AddListener(OnEnemyKill);
    }

    private void OnEnemyKill()
    {
        currentAmount++;
        Evaluate();
        ObjectiveEvent.onGoalUpdate.Invoke();
    }
}
