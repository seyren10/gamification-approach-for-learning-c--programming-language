using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/C# Book/Topic", fileName = "New C# Topic")]
public class CSharpTopicSO : ScriptableObject
{
    public string title;
    public CSharpSubTopicSO[] cSharpSubTopics;

}

