using System;
public static class ObjectiveEvent
{
    //Goal Events
    public static readonly BaseEvent onGoalCompleted = new BaseEvent();
    public static readonly BaseEvent onGoalUpdate = new BaseEvent();


    public static readonly BaseEvent<Collectible> onCollect = new BaseEvent<Collectible>();
}
