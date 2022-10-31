using UnityEngine;
using System.Text.RegularExpressions;

[CreateAssetMenu(menuName = "Scriptable Object/Regex Goal")]
public class RegexGoal : GoalSO
{
    [SerializeField]
    [TextArea(5, 10)]
    private string pattern;

    [Header("Specific Line Match")]
    [SerializeField] private bool targetLine;
    [SerializeField] private int targetIndex;

    [Header("Grouping Capture")]
    [SerializeField] private bool captureGroup;
    [SerializeField] private int groupIndex;
    [SerializeField] private string startPattern;
    [SerializeField] private string endPattern;


    public virtual void CheckPattern(string text)
    {
        Regex regex = new Regex(@pattern, RegexOptions.Multiline);

        MatchCollection mc = regex.Matches(text);

        if (!captureGroup)
        {
            if (targetLine)
            {
                if (mc.Count >= targetIndex)
                {
                    RegexMatch();
                }
            }
            else
            {
                foreach (Match m in mc)
                {
                    Debug.Log("Matches: " + m.Value);

                    RegexMatch();
                }
            }
        }
        else
        {
            if (mc.Count > 0)
            {
                string capturePattern = startPattern + mc[0].Groups[groupIndex].Value.Trim() + endPattern;
                Debug.Log("Captured Pattern: " + capturePattern);
                Regex regexG = new Regex(@capturePattern);
                if (regexG.IsMatch(text))
                {
                    RegexMatch();
                }
            }

        }
    }

    private void RegexMatch()
    {
        currentAmount++;
        Evaluate();

        ObjectiveEvent.onGoalUpdate.Invoke();
    }
}
