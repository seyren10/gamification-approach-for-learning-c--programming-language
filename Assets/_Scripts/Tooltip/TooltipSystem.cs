using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    //cached references
    [SerializeField] private Tooltip tooltip;

    //Instance
    public static TooltipSystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    public static void Show(string contentText, string headerText = "")
    {
        Instance.tooltip.SetText(contentText, headerText);
        Instance.tooltip.gameObject.SetActive(true);
    }

    public static void Hide() => Instance.tooltip.gameObject.SetActive(false);
}
