using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
     //cached ref
    private PlayerChat playerChat;
    private ActionController actionController;

    public string Message {get; private set;}

    //instance
    public static Hero Instance;

    private void Awake()
    {
     Instance = this;
    }

    private void Start()
    {
        playerChat = PlayerChat.Instance;
        actionController = ActionController.Instance;
    }

    public void Say(object message)
    {
        Message = message.ToString();

        SayCommand sayCommand = new SayCommand(Message);
        actionController.AddCommand(sayCommand);


        PrintGoalObjectiveCheck();
    }

    private void  PrintGoalObjectiveCheck()
    {

        PrintGoal.Instance.CheckString(Message);
    }

    

   
}
