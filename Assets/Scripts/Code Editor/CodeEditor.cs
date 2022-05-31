using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeEditor : MonoBehaviour
{
    [SerializeField] private TextAsset codeTemplate;
    [SerializeField] private TMP_InputField textEditorWindow;

    private CodeDomain codeDomain;

    // Start is called before the first frame update
    void Start()
    {
        ResetCode();
        codeDomain = new CodeDomain();
    }

    public void ResetCode()
    {
        textEditorWindow.text = codeTemplate.text;
    }

    public void RunCode()
    {
        codeDomain.Init();
        codeDomain.RunCode(textEditorWindow.text);
    }
}
