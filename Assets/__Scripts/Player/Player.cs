using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //cached
    private Animator animator;
    private Health health;

    //config
    //state


    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    private void Start()
    {
        //event: when enemy hit the player
        health.OnTakeDamage.AddListener(Health_OnTakeDamage);
    }

    private void Health_OnTakeDamage()
    {
        //play hurt animation
        animator.SetTrigger("hurt");
    }
}
