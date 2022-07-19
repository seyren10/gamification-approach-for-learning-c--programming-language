using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class Tooltip : MonoBehaviour
{

    //cached references
    [SerializeField] private TextMeshProUGUI headerField;
    [SerializeField] private TextMeshProUGUI contentField;
    [SerializeField] private LayoutElement layoutElement;
    private RectTransform rectTransform;

    //configuration
    [SerializeField] private int characterWrapLimit;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void SetText(string contentText, string headerText = "")
    {
        if (string.IsNullOrEmpty(headerText))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = headerText;
        }

        contentField.text = contentText;

        //control the width of the tooltip automatically
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }

    private void Update()
    {
        //mouse position
        Vector2 mousePosition = Input.mousePosition;

        //pivot
        float pivotX = mousePosition.x / Screen.width;
        float pivotY = mousePosition.y / Screen.height;


        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = mousePosition;
    }

}
