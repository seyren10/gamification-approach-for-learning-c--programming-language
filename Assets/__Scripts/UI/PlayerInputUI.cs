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

    public string inputText;

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
        inputText = inputUI.transform.Find("inputField").GetComponent<TMP_InputField>().text;
    }

    public void SetEnemyNameUI(string name)
    {
        enemyName = name;
        transform.Find("enemyNameText").GetComponent<TMP_Text>().text = "Enemy Name: " + "<#1F8A70>" + enemyName + "</color>";
    }
}
