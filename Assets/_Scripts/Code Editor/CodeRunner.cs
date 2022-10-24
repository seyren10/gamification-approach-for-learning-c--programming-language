using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeRunner : MonoBehaviour
{
    private Button btnRunCode;

    private bool firstRun;

    private void Awake()
    {
        btnRunCode = GetComponent<Button>();
        btnRunCode.onClick.AddListener(RunCode);

        firstRun = true;
    }

    private void Start()
    {
        //EVENT SUBSCRIBE
        ActionController.Instance.OnQueueFinish += ActionController_OnQueueFinish;

    }

    //EVENT CALL, this is to enable the run button when all the actions are finished performing
    //this is to prevent unnecessary movement of the player or prevent user from 
    //clicking the button repeadtedly.
    public void ActionController_OnQueueFinish(object sender, System.EventArgs e)
    {
        btnRunCode.enabled = true;
    }

    private void RunCode()
    {
        //disable the click button until all the actions are finished playing
        btnRunCode.enabled = false;

        //CLear log error text
        if (LogErrorUI.Instance != null)
            LogErrorUI.Instance.ClearErrorText();

        //level must not reset on the first run.
        if (firstRun)
        {
            firstRun = false;

            //run code on textfield. IMPORTANT: this code has to be run on the end of this this method
            CodeEditor.Instance.RunCode();
        }
        else
        {
            //reset level
            LevelEvent.OnRunCode.Invoke();

            //run code on textfield. IMPORTANT: this code has to be run on the end of this this method
            CodeEditor.Instance.RunCode();


        }
    }
}
