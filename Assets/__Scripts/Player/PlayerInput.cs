using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IOnactionComplete
{
    [SerializeField] private PlayerInputUI playerInputUI;
    //Instance
    public static PlayerInput Instance;

    public event EventHandler onActionComplete;

    //config
    [SerializeField] private Vector2 DetectionBoxSize;
    [SerializeField] private Vector2 offset;
    [SerializeField] private LayerMask whatIsEnemy;


    private void Awake()
    {
        Instance = this;
    }

    public void ShowInputUI()
    {
        //use weapon as input
        PlayerWeapon.Instance.UseByInput = true;

        //check if there's an enemy nearby
        Collider2D enemyDetected = Physics2D.OverlapBox(transform.position + (Vector3)offset, DetectionBoxSize, 0f, whatIsEnemy);
        //return when overlapbox detects nothing
        if (enemyDetected != null)
        {
            Enemy enemy = enemyDetected.GetComponent<Enemy>();
            string enemyName = enemy.GetEnemyName();
            playerInputUI.SetEnemyNameUI(enemyName);
        }

        playerInputUI.ShowInput();

        //disable enemy attack
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            enemy.CanAttack = false;
        }
    }

    public void ActionComplete()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            enemy.CanAttack = true;
        }

        onActionComplete?.Invoke(this, EventArgs.Empty);
    }


    //for visuals
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + (Vector3)offset, DetectionBoxSize);
    }
}
