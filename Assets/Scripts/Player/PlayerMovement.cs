using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IOnactionComplete
{
    //cached ref
    private Transform movePoint;
    private Animator animator;
    private SpriteRenderer[] bodyParts;
    [SerializeField] private Transform startTransform;

    //config
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private int movementStep = 3;


    //state
    private bool movementStarted; //to ensure that the player can move only if they give one of the methods has being called.

    private Vector2 playerLastPosition;

    //instance
    public static PlayerMovement Instance;

    public event EventHandler onActionComplete;

    private bool collided;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        bodyParts = GetComponentsInChildren<SpriteRenderer>();

        //dettach movePoint transform from the player
        movePoint = transform.Find("movePoint");
        movePoint.SetParent(null);

        //instance
        Instance = this;

        //event: user click the run code button
        LevelEvent.OnRunCode.AddListener(ResetPosition);
    }

    private void Update()
    {

        if (collided)
        {
            //reset position to prevent player from walking outside the bounding area(collision area)
            ResetPosition();
            ActionComplete();

            collided = false;
        }

        float distance = Vector2.Distance(transform.position, movePoint.position);

        transform.position = Vector2.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);

        //if the player reaches the movePoint and the movement has started
        if (distance == 0 && movementStarted)
        {
            ActionComplete();
        }
    }
    public void MoveUp()
    {
        playerLastPosition = transform.position;

        animator.SetBool("isMoving", true);
        //move the movePoint to North
        Vector2 moveDirection = Vector2.up;
        //reseting the movePoint position relative to the players position before the translation
        movePoint.position = transform.position;
        movePoint.Translate(moveDirection * movementStep);

        movementStarted = true;
    }
    public void MoveDown()
    {
        playerLastPosition = transform.position;

        animator.SetBool("isMoving", true);
        //move the movePoint to South
        Vector2 moveDirection = Vector2.down;
        //reseting the movePoint position relative to the players position before the translation
        movePoint.position = transform.position;
        movePoint.Translate(moveDirection * movementStep);

        movementStarted = true;

    }
    public void MoveLeft()
    {
        playerLastPosition = transform.position;


        animator.SetBool("isMoving", true);
        //move the movePoint to West
        Vector2 moveDirection = Vector2.left;

        //reseting the movePoint position relative to the players position before the translation
        movePoint.position = transform.position;
        movePoint.Translate(moveDirection * movementStep);

        movementStarted = true;

        //flip sprite to the left
        foreach (var bodypart in bodyParts)
        {
            //skip flipping the hands because it doesnt make any sense, duhhhh~
            if (bodypart.name == "right hand" || bodypart.name == "left hand")
                continue;
            bodypart.flipX = true;
        }


    }
    public void MoveRight()
    {
        playerLastPosition = transform.position;

        animator.SetBool("isMoving", true);
        //move the movePoint to East
        Vector2 moveDirection = Vector2.right;

        //reseting the movePoint position relative to the players position before the translation
        movePoint.position = transform.position;
        movePoint.Translate(moveDirection * movementStep);

        movementStarted = true;

        //flip sprite to the right
        foreach (var bodypart in bodyParts)
        {
            //skip flipping the hands because it doesnt make any sense, duhhhh~
            if (bodypart.name == "right hand" || bodypart.name == "left hand")
                continue;
            bodypart.flipX = false;
        }
    }

    private void ResetPosition()
    {
        transform.position = startTransform.position;
        movePoint.position = startTransform.position;
    }

    private void ActionComplete()
    {
        animator.SetBool("isMoving", false);
        movementStarted = false;


        //Action Completed, Trigger the event
        onActionComplete?.Invoke(this, EventArgs.Empty);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
            collided = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Goal"))
            Debug.Log("Game Finished");
    }


}