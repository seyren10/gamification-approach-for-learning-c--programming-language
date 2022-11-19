using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text bannerText;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text levelText;


    public void SetBannerText(string text)
    {
        bannerText.text = text;
    }

    public void SetTitleText(LevelType levelType)
    {
        titleText.text = levelType.ToString();
    }

    public void SetLevelText(string levelName)
    {
        string[] a = levelName.Split(' ');
        levelText.text = a[a.Length - 1];
    }
}
