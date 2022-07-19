using System;
public static class ObjectiveEvent
{
    //Goal Events
    public static BaseEvent onGoalCompleted = new BaseEvent();
    public static BaseEvent onGoalUpdate = new BaseEvent();
    public static BaseEvent onGoalReset = new BaseEvent();


    public static BaseEvent<Collectible> onCollect = new BaseEvent<Collectible>();
    public static BaseEvent onEnemyKill = new BaseEvent();

    public static void Init()
    {

        onGoalCompleted = new BaseEvent();
        onGoalUpdate = new BaseEvent();
        onGoalReset = new BaseEvent();


        onCollect = new BaseEvent<Collectible>();
        onEnemyKill = new BaseEvent();
    }
}
