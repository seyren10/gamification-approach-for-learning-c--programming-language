using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ObjectiveUI : MonoBehaviour
{
    //cached ref
    [SerializeField] private ObjectiveSO objective;

    [Header("Goal Config")]
    [SerializeField] private Transform goalTemplate;
    [SerializeField] private GoalSpriteInfo goalSpriteInfo;


    //state
    private Dictionary<GoalSO, Transform> goalTemplateDictionary;
    private void Awake()
    {
        goalTemplateDictionary = new Dictionary<GoalSO, Transform>();
        objective.Init();
    }

    private void Start()
    {
        //events: goal events
        ObjectiveEvent.onGoalCompleted.AddListener(Goal_OnGoalCompleted);
        ObjectiveEvent.onGoalUpdate.AddListener(UpdateGoalUI);

        //event: when user click the run code button
        LevelEvent.OnRunCode.AddListener(ResetGoalUI);

        //event: when user finish the level
        LevelEvent.OnLevelCompleted.AddListener(LevelCompeleted);





        foreach (var goal in objective.goals)
        {
            var newGoalTemplate = Instantiate(goalTemplate, goalTemplate.GetComponentInParent<Transform>());

            newGoalTemplate.gameObject.SetActive(true);

            newGoalTemplate.Find("description").GetComponent<TMP_Text>().text = goal.description;

            goalTemplateDictionary[goal] = newGoalTemplate;
        }

        UpdateGoalUI();
    }

    private void Goal_OnGoalCompleted()
    {
        foreach (var goal in objective.goals)
        {
            Transform goalTransform = goalTemplateDictionary[goal];
            if (goal.Completed())
            {
                goalTransform.Find("statusIcon").GetComponent<Image>().sprite = goalSpriteInfo.goalCompleteSprite;
            }
        }
    }

    private void UpdateGoalUI()
    {
        foreach (var goal in objective.goals)
        {
            Transform goalTransform = goalTemplateDictionary[goal];
            goalTransform.Find("goalStatus").GetComponent<TMP_Text>().text = $"{goal.GetCurrentAmount()}/{goal.requiredAmount}";
        }
    }

    private void ResetGoalUI()
    {
        foreach (var goal in objective.goals)
        {
            Transform goalTransform = goalTemplateDictionary[goal];
            goalTransform.Find("statusIcon").GetComponent<Image>().sprite = goalSpriteInfo.goalIncompleteSprite;
        }

        UpdateGoalUI();
    }

    private void LevelCompeleted()
    {
        foreach (var goal in objective.goals)
        {
            Transform goalTransform = goalTemplateDictionary[goal];
            if (!goal.Completed())
            {
                goalTransform.Find("statusIcon").GetComponent<Image>().sprite = goalSpriteInfo.goalFailedSprite;
            }
        }
    }
}

[Serializable]
public struct GoalSpriteInfo
{
    public Sprite goalIncompleteSprite;
    public Sprite goalCompleteSprite;
    public Sprite goalFailedSprite;
}
