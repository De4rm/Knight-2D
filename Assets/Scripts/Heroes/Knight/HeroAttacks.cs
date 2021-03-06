using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HeroAttacks : MonoBehaviour
{

    

    private Animator anim;


    public Transform attackPosition;
    public float attackRange;
    public LayerMask enemyLayerMask;

    public int minAttackPower;
    public int maxAttackPower;
    public float secondsBetweenAttacks;

    private float timeToAttack;
    
    
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        Attack();
    }
    

    void Attack()
    {
    
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Random rd = new Random();

            if (timeToAttack <= 0)
            {
                string str = "Attack" + rd.Next(1, 4);
                anim.SetBool(str, true);

                Collider2D[] enemiesToDamage =
                    Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyLayerMask);

                foreach (Collider2D enemy in enemiesToDamage)
                {

                    enemy.GetComponent<Enemy>().TakeDamage(rd.Next(minAttackPower, maxAttackPower));
                    timeToAttack = secondsBetweenAttacks;
                }

            } 

        }
        else
        {
            
            anim.SetBool("Attack1" , false);
            anim.SetBool("Attack2" , false);
            anim.SetBool("Attack3" , false);
        }

        timeToAttack -= Time.deltaTime;
        
       
        
    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPosition.position, attackRange);
    }
    
    
    
}//class




