using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[CreateAssetMenu(menuName = "Scriptable Object/Line Code Goal")]
public class LineCodeGoal : GoalSO
{

    public int maxLineCode; //the maximum line of code needed to complete this goal
    public static LineCodeGoal Instance;

    //state
    private string codeText;
    private int lineCodeCount;
    public override void Init()
    {
        //initialize base class for current amount and completed
        base.Init();
        lineCodeCount = 0;

        Instance = this;
    }

    public void EvaluateLineCount()
    {
        //added a different goal incrementation
        if (lineCodeCount <= maxLineCode)
        {
            currentAmount++;
        }

        Evaluate();
    }

    public void SetCodeText(string code)
    {


        codeText = code;

        //converting the input field code into an array separated by Return or Enter key
        var codeTexts = codeText.Split(new string[] { "\n" }, StringSplitOptions.None);

        var startingIndex = 0;


        //setting the starting position of the array below the "public void Main()"
        //to start the detection
        for (int i = 0; i < codeTexts.Length; i++)
        {
            if (codeTexts[i].Contains("public void Main()"))
            {
                startingIndex = i;
                break;
            }
        }

        //CodeException is a class that check whether the given string has a certain text.
        CodeExcemption codeEx = new CodeExcemption();

        //adding +1 to the starting index to exclude "public void Main()" in the detection
        for (int i = startingIndex + 1; i < codeTexts.Length; i++)
        {
            //this is to ensure that comments curly braces and whitespaces are not counted as a line of code.
            if (!codeEx.IsBlank(codeTexts[i])
                && !codeEx.IsComment(codeTexts[i])
                && !codeEx.IsLeftCurly(codeTexts[i])
                && !codeEx.IsRightCurly(codeTexts[i]))
            {
                lineCodeCount++;
                Debug.Log("Text: " + codeTexts[i] + "@: " + i.ToString());
            }
        }

        EvaluateLineCount();
        ObjectiveEvent.onGoalUpdate.Invoke();
    }
}

public class CodeExcemption
{
    public bool IsBlank(string text) => string.IsNullOrWhiteSpace(text);
    public bool IsComment(string text) => text.Contains("//");
    public bool IsLeftCurly(string text)
    {
        var trimmedString = text.TrimStart().TrimEnd();
        return trimmedString[0] == '{';
    }

    public bool IsRightCurly(string text)
    {
        var trimmedString = text.TrimStart().TrimEnd();
        return trimmedString[0] == '}';
    }
}