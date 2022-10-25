using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Guided Movement/Auto Move")]
public class AutoMoveSO : ScriptableObject
{
    [SerializeField] private MoveData[] moveDataArray;
    public void Move(Boots boots)
    {
        foreach (MoveData moveData in moveDataArray)
        {
            var moveDir = moveData.moveDirection;

            switch (moveDir)
            {
                case MoveDirection.Left:
                    boots.MoveLeft(moveData.moveTimes);
                    break;
                case MoveDirection.Right:
                    boots.MoveRight(moveData.moveTimes);
                    break;
                case MoveDirection.Up:
                    boots.MoveUp(moveData.moveTimes);
                    break;
                case MoveDirection.Down:
                    boots.MoveDown(moveData.moveTimes);
                    break;
            }
        }
    }


}

[System.Serializable]
public struct MoveData
{
    public MoveDirection moveDirection;
    public int moveTimes;
}

public enum MoveDirection
{
    Left,
    Right,
    Up,
    Down
}
