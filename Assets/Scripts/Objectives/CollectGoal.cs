using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Collect Goal")]
public class CollectGoal : GoalSO
{
    public CollectibleType collectibleType;

    public override void Init()
    {
        base.Init();

        ObjectiveEvent.onCollect.AddListener(OnCollect);
    }

    private void OnCollect(Collectible collectibleType)
    {

        if (this.collectibleType == collectibleType.GetCollectibleType())
        {
            currentAmount++;
            Evaluate();

            ObjectiveEvent.onGoalUpdate.Invoke();
        }
    }

}

public enum CollectibleType
{
    CornSeed
}
