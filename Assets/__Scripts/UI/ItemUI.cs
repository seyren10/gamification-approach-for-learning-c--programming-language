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

        foreach (ItemSO item in itemListSO.list)
        {
            //creating the template
            Transform newItem = Instantiate(itemTemplate, itemTemplate.GetComponentInParent<Transform>());
            newItem.gameObject.SetActive(true);

            //apply image to the template
            Image itemImage = newItem.Find("itemImage").GetComponent<Image>();
            itemImage.sprite = item.graphic;

            //apply item name to the template
            TMP_Text itemText = newItem.Find("itemText").GetComponent<TMP_Text>();
            itemText.text = item.itemType.ToString();

            //getting the itemMethod template to list all the available methods
            Transform itemMethods = newItem.Find("itemMethods");
            Button methodTemplate = itemMethods.Find("methodTemplate").GetComponent<Button>();
            methodTemplate.gameObject.SetActive(false);


            //populating the itemMethod template
            //with available methods in itemSO
            ItemMethods(item, itemMethods, methodTemplate);

        }
    }

    private void ItemMethods(ItemSO item, Transform itemMethods, Button methodTemplate)
    {
        //iterating through each method in itemSO
        foreach (ItemMethod itemMethod in item.itemMethods)
        {
            Button newMethodTemplate = Instantiate(methodTemplate, itemMethods);
            newMethodTemplate.gameObject.SetActive(true);

            //setting the method name to template
            TMP_Text newMethodTemplateText = newMethodTemplate.GetComponentInChildren<TMP_Text>();
            newMethodTemplateText.text = itemMethod.methodName;

            //add listener when user click the button
            newMethodTemplate.onClick.AddListener(() =>
            {
                //display the method description
                itemMethodDesc.gameObject.SetActive(true);
                itemMethodDesc.Find("itemMethodName").GetComponent<TMP_Text>().text = newMethodTemplateText.text;
                itemMethodDesc.Find("itemMethodDesc").GetComponent<TMP_Text>().text = itemMethod.methodDesc;
                itemMethodDesc.Find("itemUsage").Find("text").GetComponent<TMP_Text>().text = itemMethod.methodUsage;
                itemMethodDesc.Find("itemUsageDesc").GetComponent<TMP_Text>().text = itemMethod.usageDescription;
                itemMethodDesc.Find("methodSignature").Find("text").GetComponent<TMP_Text>().text = itemMethod.methodSignature;

            });
        }
    }
}
