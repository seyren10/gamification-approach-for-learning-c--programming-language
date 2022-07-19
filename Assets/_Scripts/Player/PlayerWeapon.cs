using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour, IOnactionComplete
{
    //INSTANCE
    public static PlayerWeapon Instance;

    //cached
    private Animator animator;
    private Transform playerPosition;
    private Enemy[] enemies;
    private string enemyName;

    private Enemy targetEnemy;


    //config
    [SerializeField] private int damage;
    [SerializeField] private Vector2 DetectionBoxSize;
    [SerializeField] private Vector2 offset;
    [SerializeField] private LayerMask whatIsEnemy;

    public event EventHandler onActionComplete;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        //instance
        Instance = this;
    }

    public void Attack(string enemyName)
    {
        this.enemyName = enemyName;

        //check if there's an enemy nearby
        Collider2D[] enemiesDetected = Physics2D.OverlapBoxAll(transform.position + (Vector3)offset, DetectionBoxSize, 0f, whatIsEnemy);

        //return when overlapbox detects nothing
        if (enemiesDetected == null)
        {
            animator.SetTrigger("attack");
            return;
        }

        //attempt to attack
        enemies = EnemyDetected(enemiesDetected);

        //play attack animation
        animator.SetTrigger("attack");
    }

    //call in PlayerAttackStateMachine when attack animation is triggered
    public void AttackComplete()
    {
        //getting the proper target
        targetEnemy = TargetEnemy(enemies);

        //apply damage to enemy
        if (enemies != null && targetEnemy != null)
        {
            targetEnemy.GetComponent<Health>().TakeDamage(damage);
        }
        else
        {
            Debug.Log("Wrong enemy or No Enemy Detected");
            //event Invoker: when theres no enemy or wrong enemy detected
        }

        onActionComplete?.Invoke(this, EventArgs.Empty);
    }

    private Enemy[] EnemyDetected(Collider2D[] enemiesDetected)
    {
        List<Enemy> enemyList = new List<Enemy>();

        foreach (var e in enemiesDetected)
        {
            if (e.GetComponent<Enemy>())
            {
                enemyList.Add(e.GetComponent<Enemy>());
            }
        }

        return enemyList.ToArray();
    }

    private Enemy TargetEnemy(Enemy[] enemies)
    {
        foreach (var e in enemies)
        {
            if (e.GetEnemyName() == enemyName)
            {
                return e;
            }
        }

        return null;
    }

    //for visuals
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)offset, DetectionBoxSize);
    }
}
