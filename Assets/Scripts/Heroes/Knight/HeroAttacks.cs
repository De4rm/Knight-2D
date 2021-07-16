using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HeroAttacks : MonoBehaviour
{

    [SerializeField] private float attackPower;

    private Animator anim;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;

    public Transform attackPosition;
    public float attackRange;
    public LayerMask enemyLayerMask;

    public int minAttackPower;
    public int maxAttackPower;
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

    }
    

    void Attack()
    {
    
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Random rd = new Random();
            
            Collider2D[] enemiesToDamage =
                Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyLayerMask);

            foreach (Collider2D enemy in enemiesToDamage)
            {
                
                enemy.GetComponent<Enemy>().TakeDamage(rd.Next(minAttackPower, maxAttackPower));
            }
            
            anim.SetBool("Attack" + rd.Next(1,3), true);
        }
        else
        {
            anim.SetBool("Attack1" , false);
            anim.SetBool("Attack2" , false);
            anim.SetBool("Attack3" , false);
        }

        
       
        
    }


    void AttackTry(KeyCode key, string animationStr)
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPosition.position, attackRange);
    }
}//class
