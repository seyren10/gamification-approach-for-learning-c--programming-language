using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CLIENT
public class Boots : MonoBehaviour
{
    //cached ref
    private PlayerMovement playerMovement;
    private ActionController actionController;

    //instance
    public static Boots Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerMovement = PlayerMovement.Instance;
        actionController = ActionController.Instance;
    }

    public void MoveUp(int repeat = 1)
    {
        MoveUpCommand moveUpCommand = new MoveUpCommand(playerMovement);
        Move(moveUpCommand, repeat);
    }
    public void MoveDown(int repeat = 1)
    {
        MoveDownCommand moveDownCommand = new MoveDownCommand(playerMovement);
        Move(moveDownCommand, repeat);
    }
    public void MoveLeft(int repeat = 1)
    {
        MoveLeftCommand moveLeftCommand = new MoveLeftCommand(playerMovement);
        Move(moveLeftCommand, repeat);
    }
    public void MoveRight(int repeat = 1)
    {
        MoveRightCommand moveRightCommand = new MoveRightCommand(playerMovement);
        Move(moveRightCommand, repeat);
    }


    //repeat the movement based on the given argument, 1 is default
    private void Move(ICommand repeatCommand, int repeat)
    {
        for (int i = 0; i < repeat; i++)
            actionController.AddCommand(repeatCommand);
    }
}
