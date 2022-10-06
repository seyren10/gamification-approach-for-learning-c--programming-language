using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [Header("Dialog Setup")]
    public string speakerName;
    [TextArea(4, 10)] public string message;
    public Sprite avatar;
    public TutorialAction tutorialAction;
    public bool enablePointer;

    [Header("For Trigger Action")]
    public ButtonTrigger continueTrigger;
    public Vector2 pointerPosition;
    public Vector2 fadePanelPosition;
    public Vector2 fadePanelSize;

}

public enum TutorialAction
{
    Normal,
    Trigger
}
