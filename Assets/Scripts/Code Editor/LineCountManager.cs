using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LineCountManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textEditorWindowText;
    [SerializeField] private TMP_InputField lineCountInputField;
    [SerializeField] private TMP_Text lineCountText;

    private int lineCount;

    private void Update()
    {
        //getting the code inputfield's top position to match the linecount top position
        //to line the textCount with codeTextInputfield
        lineCountText.rectTransform.offsetMax = new Vector2(
        lineCountText.rectTransform.offsetMax.x,
        textEditorWindowText.rectTransform.offsetMax.y);
    }

    public void UpdateLineCount()
    {
        //get the current lines of the code input field
        lineCount = textEditorWindowText.GetTextInfo(textEditorWindowText.text).lineCount;
        UpdateLineCountDisplay();
    }



    private void UpdateLineCountDisplay()
    {
        //updating the line count everytime there's any changes in code text
        lineCountInputField.text = "";
        for (int i = 1; i <= lineCount; i++)
        {
            lineCountInputField.text += (i + "\n");
        }
    }


}
