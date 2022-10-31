using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TooltipTrigger : MonoBehaviour
{
    [SerializeField] private string headerText;
    [SerializeField][TextArea(5, 5)] private string contentText;
    private void OnMouseOver()
    {
        TooltipSystem.Show(contentText, headerText);
    }

    private void OnMouseExit()
    {
        TooltipSystem.Hide();
    }
}
