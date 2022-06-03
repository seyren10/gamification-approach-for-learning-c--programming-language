using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CodeEditorManager : MonoBehaviour
{
    //cached ref
    [SerializeField] private TMP_InputField codeEditorInput;
    private TMP_Text iFTextComponent;


    //state variables
    int indentCount;
    bool inputFieldSelected;
    private int caretPosition;
    private string textToValidate;

    private void Start()
    {
        codeEditorInput.onSelect.AddListener(InputSelected);
        codeEditorInput.onDeselect.AddListener(InputDeselected);

        iFTextComponent = codeEditorInput.textComponent;
    }

    private void Update()
    {
        //runs only when the user is inside the input field
        if (inputFieldSelected)
        {
            /*Get the caret current position, and evaluate
            the inputField text up to the caret position
            */
            caretPosition = codeEditorInput.caretPosition;
            textToValidate = codeEditorInput.text.Substring(0, caretPosition);

            int openBracketCount = 0;
            openBracketCount = CountBracket(openBracketCount);
            indentCount = openBracketCount;
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            string indent = "";
            indent = AddIndentText(indent);

            //insert the indent on caret's position
            string newInputText = string.Concat(iFTextComponent.text.Substring(0, caretPosition), indent, iFTextComponent.text.Substring(caretPosition, iFTextComponent.text.Length - caretPosition - 1));
            //update the inputfields text with indent.
            codeEditorInput.text = newInputText;

            //update the caret positiion
            StartCoroutine(RepositionCaret(indent.Length));
        }


    }

    //add indent tag(\t) to string create indentation to the indent string
    //then return that indented string
    private string AddIndentText(string indent)
    {
        for (int i = 0; i < indentCount; i++)
        {
            indent += "\t";
        }

        return indent;
    }

    //count the bracket of input fields text
    //then return that calculated count
    private int CountBracket(int openBracketCount)
    {
        foreach (char textChar in textToValidate)
        {
            if (textChar == '{')
                openBracketCount++;
            else if (textChar == '}')
                openBracketCount--;
        }

        return openBracketCount;
    }

    //We use IEnumerator to make a little delay
    //before updating the caret position
    //to ensure that the UI rendered first before the update of caret's position.
    private IEnumerator RepositionCaret(int indentLength)
    {
        yield return new WaitForEndOfFrame();
        codeEditorInput.caretPosition = caretPosition + indentLength;
        codeEditorInput.ForceLabelUpdate();
    }


    private IEnumerable<string> EnumerateLines(TMP_Text text)
    {
        foreach (TMP_LineInfo line in text.GetTextInfo(text.text).lineInfo)
        {
            yield return text.text.Substring(line.firstCharacterIndex, line.characterCount);
        }
    }


    //when user click the inputfield
    private void InputSelected(string val)
    {
        inputFieldSelected = true;
    }

    //user leaves the InputField
    private void InputDeselected(string val)
    {
        inputFieldSelected = false;
    }

}
