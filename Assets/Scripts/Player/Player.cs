using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //cached
    public static Player Instance;
    private PlayerMovement playerMovement;

    //state
    private Vector2 movement;

    private void Awake()
    {
        //singleton
        Instance = this;
        playerMovement = GetComponent<PlayerMovement>();
    }

    #region Movement
    //movement
    public void MoveUp(int repeat = 1)
    {
        movement.y = 1f;
        movement.x = 0;
        PushMoveToQueue(movement, repeat);
    }
    public void MoveDown(int repeat = 1)
    {
        movement.y = -1f;
        movement.x = 0;
        PushMoveToQueue(movement, repeat);
    }
    public void MoveRight(int repeat = 1)
    {
        movement.x = 1f;
        movement.y = 0;
        PushMoveToQueue(movement, repeat);
    }
    public void MoveLeft(int repeat = 1)
    {
        movement.x = -1f;
        movement.y = 0;
        PushMoveToQueue(movement, repeat);

    }

    private void PushMoveToQueue(Vector2 movement, int repeatCount)
    {
        for (int i = 0; i < repeatCount; i++)
        {
            playerMovement.Push(movement);
        }
    }
    #endregion
}
