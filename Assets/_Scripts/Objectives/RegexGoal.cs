using UnityEngine;
using System.Text.RegularExpressions;

[CreateAssetMenu(menuName = "Scriptable Object/Regex Goal")]
public class RegexGoal : GoalSO
{
    [SerializeField]
    [TextArea(5, 10)]
    private string pattern;

    public void CheckPattern(string text)
    {
        Regex regex = new Regex(@pattern);

        MatchCollection mc = regex.Matches(text);

        foreach (Match m in mc)
        {
            Debug.Log("Matches: " + m.Value);

            currentAmount++;
            Evaluate();

            ObjectiveEvent.onGoalUpdate.Invoke();
        }
    }

}
