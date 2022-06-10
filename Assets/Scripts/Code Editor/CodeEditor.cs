using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeEditor : MonoBehaviour
{
    //cached ref
    [SerializeField] private TextAsset codeTemplate;
    [SerializeField] private TMP_InputField textEditorWindow;
    //config
    [SerializeField][TextArea(15, 15)] private string codeReferences; // add references for the user to reduce code complexity.

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
        string codeEditorModifiedText = textEditorWindow.textComponent.text;

        //insert the code references
        codeEditorModifiedText = InsertCodeReferences(codeEditorModifiedText);

        codeDomain.RunCode(codeEditorModifiedText);
    }

    private string InsertCodeReferences(string code)
    {
        int insertPosition = code.LastIndexOf('}');
        string firstString = code.Substring(0, insertPosition);

        return string.Concat(firstString, codeReferences, code[insertPosition]);
    }
}
