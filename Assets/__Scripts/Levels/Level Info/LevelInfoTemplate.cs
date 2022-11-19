using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class LevelInfoTemplate : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text levelInfoText;
    [SerializeField] private Transform starParent;

    [Header("Star")]
    [SerializeField] private Sprite activeStarSprite;
    [SerializeField] private Sprite inactiveStarSprite;

    public void SetLevelText(string levelText)
    {
        this.levelText.text = levelText;
    }

    public void SetLevelInfoText(string infoText)
    {
        levelInfoText.text = infoText;
    }

    public void SetStar(int starCount)
    {
        var starList = starParent.GetComponentsInChildren<Image>();

        foreach (var star in starList)
        {
            star.sprite = inactiveStarSprite;
        }

        for (int i = 0; i < starCount; i++)
        {
            starList[i].sprite = activeStarSprite;
        }
    }

    public void SetLevelStatus(bool levelUnlocked)
    {
        if (!levelUnlocked)
        {
            GetComponent<Button>().enabled = false;
            transform.Find("lockImage").gameObject.SetActive(true);
        }
        else
            transform.Find("lockImage").gameObject.SetActive(false);

    }

    public Button GetButton()
    {
        return GetComponent<Button>();
    }
}
