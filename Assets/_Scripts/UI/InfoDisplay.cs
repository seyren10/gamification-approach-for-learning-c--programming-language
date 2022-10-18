using UnityEngine;
using TMPro;

public class InfoDisplay : MonoBehaviour
{
    private string[] textDataArray;
    private int dataIndex;

    private TMP_Text dataText;

    private void Awake()
    {
        dataText = transform.Find("dataText").GetComponent<TMP_Text>();
    }

    public void SetTextDataArray(string[] textDataArray)
    {
        dataIndex = 0;
        this.textDataArray = textDataArray;

        DisplayText();
    }

    private void DisplayText()
    {
        dataText.text = textDataArray[dataIndex];
    }

    public void DisplayNext()
    {
        if (textDataArray == null) return;

        if (dataIndex < textDataArray.Length - 1)
            dataIndex++;

        DisplayText();
    }
    public void DisplayPrev()
    {
        if (textDataArray == null) return;

        if (dataIndex > 0)
            dataIndex--;

        DisplayText();
    }
}
