using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Health playerHealth;


    private Image heartTemplate;

    private List<Image> heartImages;
    private int heartCount;

    private void Awake()
    {
        heartImages = new List<Image>();

        heartTemplate = transform.Find("heartTemplate").GetComponent<Image>();
        heartTemplate.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshHeart();
        playerHealth.OnTakeDamage.AddListener(RefreshHeart);
    }

    private void RefreshHeart()
    {
        ClearHeartList();

        heartCount = playerHealth.GetHealth();
        for (int i = 0; i < heartCount; i++)
        {
            SpawnSingleHeart();
        }
    }

    private void ClearHeartList()
    {
        for (int i = heartImages.Count - 1; i >= 0; i--)
        {
            Destroy(heartImages[i].gameObject);
        }
        heartImages.Clear();

    }

    private void SpawnSingleHeart()
    {
        var temp = Instantiate(heartTemplate, transform);
        temp.gameObject.SetActive(true);
        heartImages.Add(temp);
    }
}
