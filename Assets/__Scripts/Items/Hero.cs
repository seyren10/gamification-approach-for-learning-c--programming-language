using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class Hero : MonoBehaviour
{
    //cached ref
    private PlayerChat playerChat;
    private PlayerInput playerInput;
    private ActionController actionController;

    public string Message { get; private set; }

    //instance
    public static Hero Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerChat = PlayerChat.Instance;
        playerInput = PlayerInput.Instance;
        actionController = ActionController.Instance;
    }

    public void Say(object message)
    {
        Message = message.ToString();

        SayCommand sayCommand = new SayCommand(Message);
        actionController.AddCommand(sayCommand);


        PrintGoalObjectiveCheck();
    }

    public string ReadString()
    {
        ReadStringCommand readStringCommand = new ReadStringCommand(playerInput);
        actionController.AddCommand(readStringCommand);
        return "";
    }



    private void PrintGoalObjectiveCheck()
    {
        foreach (GoalSO goal in ObjectiveSO.Instance.goals)
        {
            if (goal.GetType() == typeof(PrintGoal))
            {
                PrintGoal pg = goal as PrintGoal;
                pg.CheckString(Message);
            }
        }


    }




}
