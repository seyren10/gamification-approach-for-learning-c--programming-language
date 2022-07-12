using UnityEngine;

[System.Serializable]
public class ItemMethod
{
    public string methodName;
    public string methodSignature;
    [TextArea(15, 15)] public string methodDesc;
    public string methodUsage;
    [TextArea(15, 15)] public string usageDescription;
}
