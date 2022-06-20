using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelEvent
{
    public static BaseEvent OnRunCode = new BaseEvent();
    public static BaseEvent OnLevelCompleted = new BaseEvent();

    public static void Init()
    {
        OnRunCode = new BaseEvent();
        OnLevelCompleted = new BaseEvent();
    }

}
