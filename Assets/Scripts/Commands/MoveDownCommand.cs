using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownCommand : ICommand
{
    private readonly PlayerMovement playerMovement;

    public MoveDownCommand(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void Execute()
    {
        playerMovement.MoveDown();
    }
}
