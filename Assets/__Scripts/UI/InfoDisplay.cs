using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InfoDisplay : MonoBehaviour
{
    private string[] textDataArray;
    private int dataIndex;

    private TMP_Text dataText;
    private Button btnPrev;
    private Button btnNext;

    private void Awake()
    {
        dataText = transform.Find("dataText").GetComponent<TMP_Text>();
        btnPrev = transform.Find("btnPrev").GetComponent<Button>();
        btnNext = transform.Find("btnNext").GetComponent<Button>();
    }

    public void SetTextDataArray(string[] textDataArray)
    {
        btnNext.interactable = false;
        btnPrev.interactable = false;

        dataIndex = 0;
        this.textDataArray = textDataArray;

        DisplayText();

        if (textDataArray.Length > 1)
            btnNext.interactable = true;
    }

    private void DisplayText()
    {
        dataText.text = textDataArray[dataIndex];
    }

    public void DisplayNext()
    {
        if (textDataArray == null) return;

        if (dataIndex < textDataArray.Length - 1)
        {
            dataIndex++;
            btnPrev.interactable = true;
        }

        if (dataIndex >= textDataArray.Length - 1)
            btnNext.interactable = false;


        DisplayText();
    }
    public void DisplayPrev()
    {
        if (textDataArray == null) return;

        if (dataIndex > 0)
        {
            dataIndex--;
            btnNext.interactable = true;
        }

        if (dataIndex <= 0)
            btnPrev.interactable = false;

        DisplayText();
    }
}
