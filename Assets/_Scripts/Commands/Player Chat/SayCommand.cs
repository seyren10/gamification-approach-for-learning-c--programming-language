using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayCommand : ICommand
{
   private string message;

   public SayCommand(string message)
   {
        this.message = message;
    }
    public void Execute()
    {
        PlayerChat.Instance.Say(message);
    }
}
