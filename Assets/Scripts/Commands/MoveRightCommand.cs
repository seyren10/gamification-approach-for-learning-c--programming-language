using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : ICommand
{
    private readonly PlayerMovement playerMovement;

    public MoveRightCommand(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void Execute()
    {
        playerMovement.MoveRight();
    }
}
