using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventCollector : MonoBehaviour
{
    //instance
    public static EventCollector Instance;

    public event EventHandler OnActionCompelete;

    public void Awake()
    {
        Instance = this;
    }

    public void ActionComplete()
    {
        OnActionCompelete?.Invoke(this, EventArgs.Empty);
    }


}
