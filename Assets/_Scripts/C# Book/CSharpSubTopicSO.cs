using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/C# Book/Sub topic", fileName = "New Sub Topic")]
public class CSharpSubTopicSO : ScriptableObject
{
    public string title;

    [TextArea(20, 50)]
    public string[] textDataArray;
}
