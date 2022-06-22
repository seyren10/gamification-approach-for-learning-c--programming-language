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

    private void RunCode()
    {
        //run code on textfield. IMPORTANT: this code has to be run on the end of this this method

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
