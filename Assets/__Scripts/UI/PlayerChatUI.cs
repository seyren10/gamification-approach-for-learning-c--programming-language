
using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerChatUI : MonoBehaviour
{
    [SerializeField] private GameObject playerChatUI;

    private TMP_Text contentText;

    private void Awake()
    {
        contentText = playerChatUI.GetComponentInChildren<TMP_Text>();
    }

    public void Show(string message)
    {
        contentText.text = message;
        playerChatUI.SetActive(true);
    }
     public void Hide()
    {
        playerChatUI.SetActive(false);
    }

}

