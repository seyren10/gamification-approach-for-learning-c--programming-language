using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private ItemListSO itemListSO;
    [SerializeField] private Transform itemTemplate;
    [SerializeField] private Transform itemMethodDesc;
    private void Awake()
    {
        itemTemplate.gameObject.SetActive(false);

        foreach (Item item in itemListSO.list)
        {
            Transform newItem = Instantiate(itemTemplate, transform);
            newItem.gameObject.SetActive(true);


            Image itemImage = newItem.Find("itemImage").GetComponent<Image>();
            itemImage.sprite = item.graphic;


            Transform itemMethods = newItem.Find("itemMethods");
            Button methodTemplate = itemMethods.Find("methodTemplate").GetComponent<Button>();
            methodTemplate.gameObject.SetActive(false);

            foreach (ItemMethod itemMethod in item.itemMethods)
            {
                Button newMethodTemplate = Instantiate(methodTemplate, itemMethods);
                newMethodTemplate.gameObject.SetActive(true);

                TMP_Text newMethodTemplateText = newMethodTemplate.GetComponentInChildren<TMP_Text>();
                newMethodTemplateText.text = itemMethod.methodName;


                newMethodTemplate.onClick.AddListener(() =>
                {
                    itemMethodDesc.gameObject.SetActive(true);
                    itemMethodDesc.Find("itemMethodName").GetComponent<TMP_Text>().text = newMethodTemplateText.text;
                    itemMethodDesc.Find("itemMethodDesc").GetComponent<TMP_Text>().text = itemMethod.methodDesc;
                });
            }

        }
    }
}
