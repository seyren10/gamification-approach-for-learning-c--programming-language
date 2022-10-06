using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private List<Dialog> dialogList;


    public List<Dialog> GetDialogs()
    {
        return dialogList;
    }
}
