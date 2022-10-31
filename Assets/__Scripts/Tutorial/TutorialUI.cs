using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private Transform fadePanel;
    [SerializeField] private Transform dialogUI;
    [SerializeField] private RectTransform clickPointer;
    [SerializeField] private float clickPointerSpeed;
    [SerializeField] private float typingSpeed = 0.08f;
    [SerializeField] private GameObject skipButton;
    [SerializeField] private GameObject normalButton;

    private Image avatar;
    private TMP_Text speakerName;
    private TMP_Text message;
    private TutorialAction tutorialAction;

    private bool isTyping;
    private Coroutine typingMessageCR;
    private string dialogMessage;

    private void Awake()
    {
        avatar = dialogUI.Find("Avatar").GetComponent<Image>();
        speakerName = dialogUI.Find("Name").GetComponent<TMP_Text>();
        message = dialogUI.Find("Message").GetComponent<TMP_Text>();
    }

    public void SetFadePanel(Vector2 position, Vector2 size)
    {
        fadePanel.GetComponent<RectTransform>().anchoredPosition = position;
        fadePanel.GetComponent<RectTransform>().sizeDelta = size;
    }

    public void SetPointerPosition(Vector2 position)
    {
        StartCoroutine(MovePointerToPosition(position));
    }

    public void DisplayDialog(Dialog dialog)
    {
        tutorialAction = dialog.tutorialAction;

        avatar.sprite = dialog.avatar;
        speakerName.text = dialog.speakerName;
        dialogMessage = dialog.message;

        typingMessageCR = StartCoroutine(TypingMessage(dialogMessage));
    }

    public void SkipTyping()
    {
        if (isTyping)
        {
            StopCoroutine(typingMessageCR);
            message.text = dialogMessage;
            skipButton.SetActive(false);


        }

        if (tutorialAction == TutorialAction.Normal)
        {
            normalButton.SetActive(true);
        }




    }

    #region "ENABLE/DISABLE COMPONENTS"
    public void DisablePointer()
    {
        clickPointer.gameObject.SetActive(false);
    }

    public void EnablePointer()
    {
        clickPointer.gameObject.SetActive(true);
    }

    public void DisableFadePanel()
    {
        fadePanel.GetComponent<RectTransform>().sizeDelta = Vector3.zero;
    }

    public void EnableNormalButton()
    {
        normalButton.SetActive(true);
    }

    public void DisableNormalButton()
    {
        normalButton.SetActive(false);
    }

    #endregion

    private IEnumerator TypingMessage(string message)
    {
        this.message.text = "";
        isTyping = true;
        skipButton.SetActive(true);

        var tag = "";
        var openTag = false;
        foreach (char letter in message)
        {
            if (IsTag(letter))
            {
                openTag = !openTag;
                tag += letter;
                continue;
            }
            else if (openTag)
            {
                tag += letter;
                continue;
            }




            this.message.text += tag + letter;
            tag = "";
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        skipButton.SetActive(false);

        if (tutorialAction == TutorialAction.Normal)
            normalButton.SetActive(true);
    }

    private bool IsTag(char letter)
    {
        return letter == '<' || letter == '>';
    }




    private IEnumerator MovePointerToPosition(Vector2 target)
    {
        while (Vector2.Distance(clickPointer.anchoredPosition, target) > 0f)
        {
            clickPointer.anchoredPosition = Vector2.MoveTowards(clickPointer.anchoredPosition, target, clickPointerSpeed * Time.deltaTime);
            yield return null;
        }
    }




}
