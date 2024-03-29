using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialUI tutorialUI;
    [SerializeField] private bool showOnStart;
    [SerializeField] private DialogManager dialogManager;

    [SerializeField] private GameObject tutorialParent;

    private List<Dialog> dialogs;
    private int dialogIndex;

    private void Awake()
    {
        dialogs = dialogManager.GetDialogs();
    }

    private void Start()
    {
        if (showOnStart)
        {
            StartDialog(dialogs[dialogIndex]);
        }

    }

    private void StartDialog(Dialog dialog)
    {
        var tutorialAction = dialog.tutorialAction;

        if (dialog.enablePointer)
            tutorialUI.EnablePointer();
        else
            tutorialUI.DisablePointer();


        switch (tutorialAction)
        {
            case TutorialAction.Normal:
                HandleDialogNormal(dialog);
                break;
            case TutorialAction.Trigger:
                HandleDialogTrigger(dialog);
                break;
        }

    }

    private void ButtonTrigger_Click()
    {
        tutorialUI.StopAllCoroutines();
        dialogs[dialogIndex].continueTrigger.GetButton().onClick.RemoveAllListeners();
        dialogIndex++;

        if (dialogIndex < dialogs.Count)
            StartDialog(dialogs[dialogIndex]);
        else
        {
            //end the tutorial
            EndTutorial();
        }

    }

    private void HandleDialogTrigger(Dialog dialog)
    {
        dialog.continueTrigger.GetButton().enabled = true;
        dialog.continueTrigger.GetButton().onClick.AddListener(ButtonTrigger_Click);


        SetUpUI(dialog);
        tutorialUI.DisplayDialog(dialog);
    }

    private void SetUpUI(Dialog dialog)
    {
        var fadePanelPos = dialog.fadePanelPosition;
        var fadePanelSize = dialog.fadePanelSize;
        var pointerTargetPos = dialog.pointerPosition;

        tutorialUI.SetFadePanel(fadePanelPos, fadePanelSize);
        tutorialUI.SetPointerPosition(pointerTargetPos);
    }

    private void HandleDialogNormal(Dialog dialog)
    {
        dialog.continueTrigger.gameObject.SetActive(true);
        dialog.continueTrigger.GetButton().enabled = true;
        dialog.continueTrigger.GetButton().onClick.AddListener(ButtonTrigger_Click);
        dialog.continueTrigger.gameObject.SetActive(false);

        SetUpUI(dialog);
        tutorialUI.DisplayDialog(dialog);
    }

    public void EndTutorial()
    {
        dialogIndex = 0;
        RemoveAllTutorialButton();
        tutorialParent.SetActive(false);
    }

    private void RemoveAllTutorialButton()
    {
        var buttonTriggersActive = FindObjectsOfType<ButtonTrigger>(true);

        foreach (var bTrigger in buttonTriggersActive)
        {
            Destroy(bTrigger);
        }
    }


}
