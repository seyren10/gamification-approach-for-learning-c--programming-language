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

    //movement
    public void MoveUp()
    {
        movement.y = 1f;
        movement.x = 0;
        playerMovement.Push(movement);
    }
    public void MoveDown()
    {
        movement.y = -1f;
        movement.x = 0;
        playerMovement.Push(movement);
    }
    public void MoveRight()
    {
        movement.x = 1f;
        movement.y = 0;
        playerMovement.Push(movement);
    }
    public void MoveLeft()
    {
        movement.x = -1f;
        movement.y = 0;
        playerMovement.Push(movement);
    }
}
