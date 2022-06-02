using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //cached ref
    private Rigidbody2D rb;

    //state
    [Header("Movement Config")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float moveStep = 3f;
    [SerializeField] private float delayBetweenMovement = .5f;

    private Vector2 movement;
    private Transform movePoint;
    private bool isPlayerAtDest;

    private float movementDelay;

    private Queue<Vector2> movementQueue;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementQueue = new Queue<Vector2>();
        movePoint = transform.Find("movePoint").GetComponent<Transform>();
    }

    private void Start()
    {
        movePoint.parent = null;
        movementDelay = delayBetweenMovement;
    }

    private void Update()
    {
        //Getting the distance of the player and movePoint
        isPlayerAtDest = Vector2.Distance(rb.position, movePoint.position) < Mathf.Epsilon ? true : false;


        //if player is not in its destination(movepoint) then Move the MovePoint
        //if the player is in its destination(movepoint), then we add delay before moving again.
        if (!isPlayerAtDest)
            SetMovePosition();
        else if (CanMove())
            MovePlayer();
    }

    public void Push(Vector2 movement)
    {
        movementQueue.Enqueue(movement);
    }

    private void SetMovePosition()
    {
        rb.position = Vector2.MoveTowards(rb.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    private void MovePlayer()
    {
        //making sure that the movement queue is not empty before Dequeing the movement
        if (movementQueue.Count > 0)
        {
            movement = movementQueue.Dequeue();

            //move the player to movePoint
            movePoint.position = (Vector2)movePoint.position + (movement * moveStep);
            movementDelay = delayBetweenMovement;
        }

    }


    private bool CanMove()
    {
        // if player is in destination, then we add delay before moving again
        if (movementDelay >= 0f)
        {
            movementDelay -= Time.deltaTime;
            return false;
        }
        return true;
    }
}
