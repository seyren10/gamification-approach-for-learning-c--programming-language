using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReadStringCommand : ICommand
{
    private readonly PlayerInput playerInput;


    public ReadStringCommand(PlayerInput playerInput)
    {
        this.playerInput = playerInput;
    }

    public void Execute()
    {
        playerInput.ShowInputUI();
    }
}
