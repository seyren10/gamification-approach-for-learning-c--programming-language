using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject : MonoBehaviour
{
    private Transform originalItems;
    private Transform copyItems;

    private void Awake()
    {
        originalItems = transform.Find("objects");
        originalItems.gameObject.SetActive(false);

        CreateItems();

        //event: when user click the run code button
        LevelEvent.OnRunCode.AddListener(ResetLevelItems);
    }

    private void ResetLevelItems()
    {
        Destroy(copyItems.gameObject);
        CreateItems();
    }

    private void CreateItems()
    {
        copyItems = Instantiate(originalItems, transform);
        copyItems.gameObject.SetActive(true);

    }
}
