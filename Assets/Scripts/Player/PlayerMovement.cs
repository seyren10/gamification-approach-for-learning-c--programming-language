using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IOnactionComplete
{
    //cached ref
    private Transform movePoint;

    //config
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private int movementStep = 3;


    //state
    private bool movementStarted; //to ensure that the player can move only if they give one of the methods has being called.

    //instance
    public static PlayerMovement Instance;

    public event EventHandler onActionComplete;

    private void Awake()
    {
        //dettach movePoint transform from the player
        movePoint = transform.Find("movePoint");
        movePoint.SetParent(null);

        //instance
        Instance = this;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, movePoint.position);

        transform.position = Vector2.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);

        //if the player reaches the movePoint and the movement has started
        if (distance == 0 && movementStarted)
        {
            movementStarted = false;
            //Action Completed, Trigger the event
            onActionComplete?.Invoke(this, EventArgs.Empty);
        }
    }

    public void MoveUp()
    {
        //move the movePoint to North
        Vector2 moveDirection = Vector2.up;
        movePoint.Translate(moveDirection * movementStep);

        movementStarted = true;
    }
    public void MoveDown()
    {
        //move the movePoint to South
        Vector2 moveDirection = Vector2.down;
        movePoint.Translate(moveDirection * movementStep);

        movementStarted = true;
    }
    public void MoveLeft()
    {
        //move the movePoint to West
        Vector2 moveDirection = Vector2.left;
        movePoint.Translate(moveDirection * movementStep);

        movementStarted = true;

    }
    public void MoveRight()
    {
        //move the movePoint to East
        Vector2 moveDirection = Vector2.right;
        movePoint.Translate(moveDirection * movementStep);

        movementStarted = true;

    }


}
