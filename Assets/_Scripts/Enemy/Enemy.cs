using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //cached ref
    private Animator animator;
    private Health health;

    //configuration
    [SerializeField] private string enemyName;
    [SerializeField] private float walkSpeed;
    [SerializeField] private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float timeBtwnAttack;

    [Header("Detection")]
    [SerializeField] private Vector2 detectionBoxSize;
    [SerializeField] private Vector2 offset;
    [SerializeField] private LayerMask whatIsPlayer;



    //state
    private Transform playerTransform;
    private Health playerHealth;
    private float attackTime;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();

        //event: when hit by player
        health.OnTakeDamage.AddListener(Health_OnTakeDamage);
        //event: when enemy get killed
        health.OnKill.AddListener(Health_OnKill);

        attackTime = timeBtwnAttack;
    }

    private void Update()
    {
        //run detection
        Collider2D target = Physics2D.OverlapBox(transform.position + (Vector3)offset, detectionBoxSize, 0f, whatIsPlayer);
        if (target == null) return;


        playerTransform = target.transform;


        if (Vector2.Distance(transform.position, playerTransform.position) > attackRange)
        {
            //move to target
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, walkSpeed * Time.deltaTime);

            //face target
            FaceTargetDirection();

            //play walk animation
            animator.SetBool("isRunning", true);
        }
        else
        {
            //stop walk animation
            animator.SetBool("isRunning", false);

            //wait for attack time
            if (attackTime >= 0f)
            {
                attackTime -= Time.deltaTime;
            }
            else
            {
                //attack
                Attack();
                attackTime = timeBtwnAttack;
            }
        }
    }

    public string GetEnemyName()
    {
        return enemyName;
    }

    //called in animation event
    public void Attack()
    {
        //play attack animation
        animator.SetTrigger("attack");

        //check to see if the target exist and there's a health component attach to it
        if (playerTransform != null && playerTransform.GetComponent<Health>() != null)
        {
            //get the health component of the target
            playerHealth = playerTransform.GetComponent<Health>();
            //attack the target
            playerHealth.TakeDamage(damage);
        }
    }

    #region "EVENT CALL"
    private void Health_OnTakeDamage()
    {
        //play hurt Animation
        animator.SetTrigger("hurt");
    }

    private void Health_OnKill()
    {
        //invoke the objective goal
        ObjectiveEvent.onEnemyKill.Invoke();
    }
    #endregion


    private void FaceTargetDirection()
    {
        //getting the direction from point a to point b
        Vector2 direction = playerTransform.position - transform.position * 1f;
        direction.Normalize();



        float finalDirection = direction.x <= Mathf.Epsilon ? 0f : 180f;


        //rotating the enemy to face the target position
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
        finalDirection,
        transform.rotation.eulerAngles.z);
    }



    //for visuals
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)offset, detectionBoxSize);
    }
}
