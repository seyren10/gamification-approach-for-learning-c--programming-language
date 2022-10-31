using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{

    private string enemyName;

    public AttackCommand(string enemyName)
    {
        this.enemyName = enemyName;
    }

    public void Execute()
    {
        PlayerWeapon.Instance.Attack(enemyName);
    }
}
