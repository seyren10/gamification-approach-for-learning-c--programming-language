using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item", fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public ItemMethod[] itemMethods;
    public Sprite graphic;
}

public enum ItemType
{
    Boots,
    Sickle

}
