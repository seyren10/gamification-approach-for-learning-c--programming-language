using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CSharpBookUI : MonoBehaviour
{
    [SerializeField] private CSharpTopicSO[] cSharpTopicArray;

    [Header("Font Color")]
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color selectedColor;

    private Transform menuItemParent;
    private Transform cSharpTemplate;

    private Transform infoDisplayPanel;

    private Dictionary<CSharpTopicSO, Transform> menuItemTransformDictionary;
    private Dictionary<CSharpSubTopicSO, Transform> subItemTransformDictionary;

    private void Awake()
    {
        menuItemParent = transform.Find("c#Menu");
        cSharpTemplate = menuItemParent.Find("contentTemplate");
        infoDisplayPanel = transform.Find("infoDisplayPanel");

        menuItemTransformDictionary = new Dictionary<CSharpTopicSO, Transform>();
        subItemTransformDictionary = new Dictionary<CSharpSubTopicSO, Transform>();
    }

    private void Start()
    {
        foreach (CSharpTopicSO cSharpTopic in cSharpTopicArray)
        {
            CreateMenuItem(cSharpTopic);
        }
    }

    private void CreateMenuItem(CSharpTopicSO cSharpTopicSO)
    {
        var newMenuItem = Instantiate(cSharpTemplate, menuItemParent);
        newMenuItem.gameObject.SetActive(true);

        var headerText = newMenuItem.Find("header").Find("headerText").GetComponent<TMP_Text>();
        headerText.text = cSharpTopicSO.title;

        menuItemTransformDictionary.Add(cSharpTopicSO, newMenuItem);

        CreateSubItem(cSharpTopicSO, newMenuItem);
    }

    private void CreateSubItem(CSharpTopicSO cSharpTopicSO, Transform newMenuItem)
    {
        var bodyParent = newMenuItem.Find("body");
        var subTopicTemplate = bodyParent.Find("btnTemplate");

        foreach (var subTopic in cSharpTopicSO.cSharpSubTopics)
        {
            var newSubtopicItem = Instantiate(subTopicTemplate, bodyParent);
            newSubtopicItem.gameObject.SetActive(true);

            var subTopicText = newSubtopicItem.Find("btnText").GetComponent<TMP_Text>();
            subTopicText.text = subTopic.title;

            var subTopicButton = newSubtopicItem.GetComponent<Button>();
            subTopicButton.onClick.AddListener(() =>
            {
                infoDisplayPanel.GetComponent<InfoDisplay>().SetTextDataArray(subTopic.textDataArray);

                //add font highlights
                ResetAllMenuColors();
                SetMenuColor(newMenuItem, newSubtopicItem);

            });

            subItemTransformDictionary.Add(subTopic, newSubtopicItem);
        }


    }

    private void ResetAllMenuColors()
    {
        foreach (var item in menuItemTransformDictionary.Values)
        {
            Transform v = item;
            v.Find("header").Find("headerText").GetComponent<TMP_Text>().color = defaultColor;
        }

        foreach (var item in subItemTransformDictionary.Values)
        {
            Transform v = item.Find("btnText");
            v.GetComponent<TMP_Text>().color = defaultColor;
        }
    }
    private void SetMenuColor(Transform menuItem, Transform subTopic)
    {
        Transform v = menuItem;
        v.Find("header").Find("headerText").GetComponent<TMP_Text>().color = selectedColor;

        var subItemText = subTopic.Find("btnText").GetComponent<TMP_Text>();
        subItemText.color = selectedColor;
    }
}
