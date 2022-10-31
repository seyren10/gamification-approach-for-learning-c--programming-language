using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class LogErrorUI : MonoBehaviour
{

    [SerializeField]
    private TMP_Text errorText;
    private string currentText = "";


    public static LogErrorUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }


    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error)
        {
            currentText += "\n" + logString;
            DisplayError();
            ActionController.Instance.ActionFinish();
        }
    }


    public void DisplayError()
    {
        errorText.text = currentText;
    }

    public void ClearErrorText()
    {
        currentText = "";
        errorText.text = "";
    }

}


