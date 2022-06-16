using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BaseEvent
{
    private event Action action;
    public BaseEvent()
    {
        action = delegate { };
    }

    public void Invoke()
    {
        action.Invoke();
    }

    public void AddListener(Action listener)
    {
        action -= listener;
        action += listener;
    }

    public void RemoveListener(Action listener)
    {
        action -= listener;
    }
}
public class BaseEvent<T>
{
    private event Action<T> action;
    public BaseEvent()
    {
        action = delegate { };
    }

    public void Invoke(T param)
    {
        action.Invoke(param);
    }

    public void AddListener(Action<T> listener)
    {
        action -= listener;
        action += listener;
    }

    public void RemoveListener(Action<T> listener)
    {
        action -= listener;
    }
}
