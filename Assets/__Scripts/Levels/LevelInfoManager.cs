using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfoManager : MonoBehaviour
{
    [SerializeField] private LevelInfoSO levelInfoSO;
    [SerializeField] private LevelInfoUI levelInfoUI;

    public static LevelInfoManager Instance;
    public LevelInfoSO GetLevelInfoSO => levelInfoSO;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        levelInfoUI.SetBannerText(levelInfoSO.levelNameInfo);
        levelInfoUI.SetTitleText(levelInfoSO.levelType);
        levelInfoUI.SetLevelText(levelInfoSO.levelName);
    }
}
