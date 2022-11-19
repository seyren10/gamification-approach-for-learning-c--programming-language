using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Object/Level Info List")]
public class LevelInfoListSO : ScriptableObject
{
    public List<LevelInfoSO> list;
}
