using UnityEngine;
using UnityEngine.UI;
using System;
public class ButtonTrigger : MonoBehaviour
{

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.enabled = false;
    }

    public Button GetButton()
    {
        return button;
    }
}
