using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CLIENT
public class Sickle : MonoBehaviour
{
    //SINGLETON
    public static Sickle Instance;
    //cached ref
    private ActionController actionController;

    private void Awake() => Instance = this;

    private void Start()
    {
        actionController = ActionController.Instance;
    }
    public void Attack(string enemyName)
    {
        AttackCommand attackCommand = new AttackCommand(enemyName);
        actionController.AddCommand(attackCommand);
    }
}
