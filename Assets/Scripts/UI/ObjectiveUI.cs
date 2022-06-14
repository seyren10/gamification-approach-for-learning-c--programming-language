using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    //cached ref
    [SerializeField] private ObjectiveSO objective;

    [Header("Goal Config")]
    [SerializeField] private Transform goalTemplate;
    [SerializeField] private Sprite goalCompleteSprite;


    //state
    private Dictionary<GoalSO, Transform> goalTemplateDictionary;
    private void Awake()
    {
        objective.Init();
    }

    private void Start()
    {
        //EVENTS
        ObjectiveEvent.onGoalCompleted.AddListener(Goal_OnGoalCompleted);
        ObjectiveEvent.onGoalUpdate.AddListener(UpdateGoalUI);

        goalTemplateDictionary = new Dictionary<GoalSO, Transform>();



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
                goalTransform.Find("statusIcon").GetComponent<Image>().sprite = goalCompleteSprite;
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
}
