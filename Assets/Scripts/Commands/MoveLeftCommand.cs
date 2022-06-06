using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : ICommand
{
    private readonly PlayerMovement playerMovement;

    public MoveLeftCommand(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void Execute()
    {
        playerMovement.MoveLeft();
    }
}
