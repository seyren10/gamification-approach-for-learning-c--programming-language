using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelFinishUI : MonoBehaviour
{
    [SerializeField] private Transform goalDisplay;
    [SerializeField] private Transform starContainer;

    private Transform goalParent;
    private Transform currentGoalDisplay;
    private Image[] starImages;

    [SerializeField] private Sprite starSprite;

    private int star;

    public int Star
    {
        get
        {
            return star;
        }
        set
        {
            if (value <= 3)
                star = value;
            else
                star = 3;

            SetStar();
        }
    }

    public void Show()
    {
        starImages = starContainer.GetComponentsInChildren<Image>();
        gameObject.SetActive(true);
        goalParent = transform.Find("goalContainer").GetComponent<Transform>();
        currentGoalDisplay = Instantiate(goalDisplay, goalParent);

        //set empty star to star images
        foreach (var i in starImages)
        {
            i.sprite = starSprite;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Destroy(currentGoalDisplay.gameObject);
    }

    private void SetStar()
    {
        //making sure that this object is active

        for (int i = 0; i < star; i++)
        {
            //set star to images depending on star attained.
            starImages[i].color = Color.white;
        }

    }
}
