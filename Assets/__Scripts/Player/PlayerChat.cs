using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerChat : MonoBehaviour, IOnactionComplete
{
    //reference
    [SerializeField] private PlayerChatUI playerChatUI;

    //config
    [SerializeField] private float msgDispTime = 3f;


    //Instance
    public static PlayerChat Instance;


    //event

    public event EventHandler onActionComplete;

    private void Awake()
    {
        Instance = this;
    }

    public void Say(string message)
    {
        StartCoroutine(DisplayWithTimer(message));
    }

    private IEnumerator DisplayWithTimer(string message)
    {
        playerChatUI.Show(message);
        yield return new WaitForSeconds(msgDispTime);
        playerChatUI.Hide();

        //action completed
        onActionComplete?.Invoke(this, EventArgs.Empty);
    }
}
