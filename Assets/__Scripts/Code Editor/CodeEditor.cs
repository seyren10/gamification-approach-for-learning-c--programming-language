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

    //instance
    public static CodeEditor Instance;

    private CodeDomain codeDomain;

    private void Awake()
    {
        //instance
        Instance = this;
    }

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

        //before inserting the code reference
        //check first for regex goals
        if (ObjectiveSO.Instance != null)
            CheckForRegexGoal(codeEditorModifiedText);

        //insert the code references
        codeEditorModifiedText = InsertCodeReferences(codeEditorModifiedText);

        codeDomain.RunCode(codeEditorModifiedText);


        //PART OF OBJECTIVE SYSTEM: making sure that LinecodeGoal is existing on scene
        if (LineCodeGoal.Instance != null)
        {
            //giving the text to evaluate
            LineCodeGoal.Instance.SetCodeText(textEditorWindow.textComponent.text);
        }


    }

    private string InsertCodeReferences(string code)
    {
        int insertPosition = code.LastIndexOf('}');
        string firstString = code.Substring(0, insertPosition);

        return string.Concat(firstString, codeReferences, code[insertPosition]);
    }

    private void CheckForRegexGoal(string text)
    {
        foreach (GoalSO goal in ObjectiveSO.Instance.goals)
        {
            if (goal.GetType() == typeof(RegexGoal))
            {
                RegexGoal rg = goal as RegexGoal;
                rg.CheckPattern(text);
            }
        }
    }




}
