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
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        timeToAttack = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        OnAttack();
    }

    void OnAttack()
    {

        if (timeToAttack == 0)
        {
            Collider2D player =
                Physics2D.OverlapCircle(attackPosition.position, attackRange, playerLayerMask);

            isPlayerNotNull = (player != null);

            if (isPlayerNotNull)
            {
                player.GetComponent<HeroDefence>().TakeDamage(attackPower);
                timeToAttack = secondsBetweenAttacks;
            }

            GetComponent<EnemyMovement>().canMoveInBounds = !isPlayerNotNull;
            anim.SetBool("Attack", isPlayerNotNull);
            
        }
        else
        {
            timeToAttack -= Time.deltaTime;
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(attackPosition.position, attackRange);
    }
}//class
