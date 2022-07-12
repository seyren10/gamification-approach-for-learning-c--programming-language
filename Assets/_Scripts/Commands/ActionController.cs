using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//INVOKER
public class ActionController : MonoBehaviour
{
    public static ActionController Instance;
    private Queue<ICommand> commandQueue;

    // private IOnactionComplete onactionComplete;
    private void Awake()
    {
        Instance = this;

        commandQueue = new Queue<ICommand>();
    }

    private void Start()
    {
        var onactionCompleteArray = FindObjectsOfType<MonoBehaviour>().OfType<IOnactionComplete>();
        foreach (IOnactionComplete item in onactionCompleteArray)
        {
            item.onActionComplete += IOnActionComplete_OnActionComplete;
        }
    }

    public void AddCommand(ICommand newCommand)
    {

        commandQueue.Enqueue(newCommand);
    }

    public void DequeueAction()
    {
        if (commandQueue.Count > 0)
        {
            ICommand dequeuedAction = commandQueue.Dequeue();
            dequeuedAction.Execute();
        }
    }

    private void IOnActionComplete_OnActionComplete(object sender, System.EventArgs e)
    {
        DequeueAction();
    }
}
