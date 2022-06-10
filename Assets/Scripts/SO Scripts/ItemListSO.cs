using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Object/Item List SO")]
public class ItemListSO : ScriptableObject
{
    public List<ItemSO> list;
}
