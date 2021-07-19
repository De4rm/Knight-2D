using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    
    private Animator anim;

    public float attackRange;
    public Transform attackPosition;
    
    
    public LayerMask playerLayerMask;
    public float secondsBetweenAttacks;
    
    public int attackPower;

    private bool isPlayerNotNull;

    private float timeToAttack;
    private EnemyMovement em;
    private GameObject player;
    
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        timeToAttack = 0f;
        em = GetComponent<EnemyMovement>();
    }

    
    
    
    void FixedUpdate()
    {
        DetectPlayer();
        OnAttack();
    }

    void OnAttack()
    {
        
        //Add timing, 
        if (timeToAttack == 0)
        {
            //find out if player is in attack range
            Collider2D player =
                Physics2D.OverlapCircle(attackPosition.position, attackRange, playerLayerMask);

            //if player variable is not null then player object is in attack range
            isPlayerNotNull = (player != null);

            if (isPlayerNotNull)
            {
                //change health variable to player object
                player.GetComponent<HeroDefence>().TakeDamage(attackPower);
                
                //renew time that enemy can attack 
                timeToAttack = secondsBetweenAttacks;
            }

            
            GetComponent<EnemyMovement>().canMoveInBounds = !isPlayerNotNull;
            
            //start or stop attack animation for enemy
            anim.SetBool("Attack", isPlayerNotNull);
            
        }
        else
        {
            //reduce time that is needed to wait for next attack 
            timeToAttack -= Time.deltaTime;
            anim.SetBool("Attack", false);
        }

    }


    void DetectPlayer()
    {
        RaycastHit2D detected = Physics2D.Raycast(attackPosition.position, Vector2.left, 5f, playerLayerMask);

        if ((detected.collider != null) || (player != null))
        {
            if (detected.collider != null)
            {
                player = detected.collider.gameObject;
            }

            em.SetCanMoveInBounds(false);
            em.SetPlayerPosition(player.transform.position.x);
        }
        else
        {
            em.SetCanMoveInBounds(true);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(attackPosition.position, attackRange);
    }
    
    
    
    
    
    
    //*********************Setters&Getters*****************************


    public float GetAttackRange()
    {
        return attackRange;
    }
    
    
    
    
    
    
    
    
}//class
