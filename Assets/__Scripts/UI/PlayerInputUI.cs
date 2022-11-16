using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading.Tasks;

public class PlayerInputUI : MonoBehaviour
{
    [SerializeField] private GameObject inputUI;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text enemyNameText;

    [HideInInspector] public string inputText;

    private string enemyName;


    public static PlayerInputUI Instance;


    private void Awake()
    {
        Instance = this;
    }

    public void ShowInput()
    {
        inputUI.SetActive(true);
    }

    public void SetInputText()
    {
        inputText = inputField.text;
    }

    public void SetEnemyNameUI(string name)
    {
        enemyName = name;
        enemyNameText.text = "Enemy Name: " + "<#1F8A70>" + enemyName + "</color>";
    }
}
