using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelSelectionManager : MonoBehaviour
{
    [SerializeField] private LevelInfoTemplate levelInfoTemplate;
    [SerializeField] private SceneLoader sceneLoader;
    private List<LevelInfoSO> levelInfoSOList;

    private void Awake()
    {
        levelInfoSOList = Resources.Load<LevelInfoListSO>(typeof(LevelInfoListSO).Name).list;
        //unlock level tutorial Level
        levelInfoSOList[0].SaveLevelStatus(true);

        levelInfoTemplate.gameObject.SetActive(false);
    }
    public void LoadBasicPrinting()
    {
        var basicPrintingLevels = levelInfoSOList.Where(a => a.levelType == LevelType.BasicPrinting);
        ClearChildren();


        foreach (var basicPrintingLevel in basicPrintingLevels)
        {
            var newLevelInfoTemplate = Instantiate(levelInfoTemplate, levelInfoTemplate.transform.parent);
            newLevelInfoTemplate.gameObject.SetActive(true);
            newLevelInfoTemplate.SetLevelText(basicPrintingLevel.levelName);
            newLevelInfoTemplate.SetLevelInfoText(basicPrintingLevel.levelNameInfo);
            newLevelInfoTemplate.SetStar(basicPrintingLevel.LoadGatheredStar());
            newLevelInfoTemplate.SetLevelStatus(basicPrintingLevel.LoadLevelStatus());

            newLevelInfoTemplate.GetButton().onClick.AddListener(() => sceneLoader.LoadScene(basicPrintingLevel.levelName));
        }
    }

    public void LoadVariables()
    {
        var loadVariableLevels = levelInfoSOList.Where(a => a.levelType == LevelType.Variables);
        ClearChildren();


        foreach (var basicPrintingLevel in loadVariableLevels)
        {
            var newLevelInfoTemplate = Instantiate(levelInfoTemplate, levelInfoTemplate.transform.parent);
            newLevelInfoTemplate.gameObject.SetActive(true);
            newLevelInfoTemplate.SetLevelText(basicPrintingLevel.levelName);
            newLevelInfoTemplate.SetLevelInfoText(basicPrintingLevel.levelNameInfo);
            newLevelInfoTemplate.SetStar(basicPrintingLevel.LoadGatheredStar());
            newLevelInfoTemplate.SetLevelStatus(basicPrintingLevel.LoadLevelStatus());

            newLevelInfoTemplate.GetButton().onClick.AddListener(() => sceneLoader.LoadScene(basicPrintingLevel.levelName));

        }
    }

    public void LoadDataTypes()
    {
        var loadDataTypeLevels = levelInfoSOList.Where(a => a.levelType == LevelType.DataTypes);
        ClearChildren();


        foreach (var basicPrintingLevel in loadDataTypeLevels)
        {
            var newLevelInfoTemplate = Instantiate(levelInfoTemplate, levelInfoTemplate.transform.parent);
            newLevelInfoTemplate.gameObject.SetActive(true);
            newLevelInfoTemplate.SetLevelText(basicPrintingLevel.levelName);
            newLevelInfoTemplate.SetLevelInfoText(basicPrintingLevel.levelNameInfo);
            newLevelInfoTemplate.SetStar(basicPrintingLevel.LoadGatheredStar());
            newLevelInfoTemplate.SetLevelStatus(basicPrintingLevel.LoadLevelStatus());

            newLevelInfoTemplate.GetButton().onClick.AddListener(() => sceneLoader.LoadScene(basicPrintingLevel.levelName));

        }
    }

    public void LoadOperators()
    {
        var loadOperatorLevels = levelInfoSOList.Where(a => a.levelType == LevelType.Operators);
        ClearChildren();


        foreach (var basicPrintingLevel in loadOperatorLevels)
        {
            var newLevelInfoTemplate = Instantiate(levelInfoTemplate, levelInfoTemplate.transform.parent);
            newLevelInfoTemplate.gameObject.SetActive(true);
            newLevelInfoTemplate.SetLevelText(basicPrintingLevel.levelName);
            newLevelInfoTemplate.SetLevelInfoText(basicPrintingLevel.levelNameInfo);
            newLevelInfoTemplate.SetStar(basicPrintingLevel.LoadGatheredStar());
            newLevelInfoTemplate.SetLevelStatus(basicPrintingLevel.LoadLevelStatus());

            newLevelInfoTemplate.GetButton().onClick.AddListener(() => sceneLoader.LoadScene(basicPrintingLevel.levelName));

        }
    }

    public void LoadConditions()
    {
        var loadConditionLevels = levelInfoSOList.Where(a => a.levelType == LevelType.Condition);
        ClearChildren();


        foreach (var basicPrintingLevel in loadConditionLevels)
        {
            var newLevelInfoTemplate = Instantiate(levelInfoTemplate, levelInfoTemplate.transform.parent);
            newLevelInfoTemplate.gameObject.SetActive(true);
            newLevelInfoTemplate.SetLevelText(basicPrintingLevel.levelName);
            newLevelInfoTemplate.SetLevelInfoText(basicPrintingLevel.levelNameInfo);
            newLevelInfoTemplate.SetStar(basicPrintingLevel.LoadGatheredStar());
            newLevelInfoTemplate.SetLevelStatus(basicPrintingLevel.LoadLevelStatus());

            newLevelInfoTemplate.GetButton().onClick.AddListener(() => sceneLoader.LoadScene(basicPrintingLevel.levelName));

        }
    }

    public void LoadUserInput()
    {
        var loadUserInputLevels = levelInfoSOList.Where(a => a.levelType == LevelType.UserInput);
        ClearChildren();


        foreach (var basicPrintingLevel in loadUserInputLevels)
        {
            var newLevelInfoTemplate = Instantiate(levelInfoTemplate, levelInfoTemplate.transform.parent);
            newLevelInfoTemplate.gameObject.SetActive(true);
            newLevelInfoTemplate.SetLevelText(basicPrintingLevel.levelName);
            newLevelInfoTemplate.SetLevelInfoText(basicPrintingLevel.levelNameInfo);
            newLevelInfoTemplate.SetStar(basicPrintingLevel.LoadGatheredStar());
            newLevelInfoTemplate.SetLevelStatus(basicPrintingLevel.LoadLevelStatus());

            newLevelInfoTemplate.GetButton().onClick.AddListener(() => sceneLoader.LoadScene(basicPrintingLevel.levelName));

        }
    }


    private void ClearChildren()
    {
        var levelInfoParent = levelInfoTemplate.transform.parent;
        Debug.Log(levelInfoParent.name);
        foreach (var levelInfoChild in levelInfoParent.GetComponentsInChildren<LevelInfoTemplate>())
        {
            Destroy(levelInfoChild.gameObject);
        }
    }

}
