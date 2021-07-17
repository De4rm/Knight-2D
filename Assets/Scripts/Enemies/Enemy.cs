using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Enemy health indicator
    public int health = 10;

    //animator object to switch animations
    private Animator anim;

    private EnemyMovement movementScript;
    
    
    
    void Awake()
    {
        //get component animator from enemy 
        anim = GetComponent<Animator>();
        movementScript = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetBool("DamageRecieve", false);

        //check if health of the enemy is still more than 0
        if (health <= 0)
        {
            //start "Dead" trigger in animator
            anim.SetTrigger("Dead");
            //stop enemy to move after death
            movementScript.canMoveInBounds = false;

            Vector3 temp = transform.position;
            temp.z = -2;
            transform.position = temp;
            
            //start courotine to destroy dead enemy object
            StartCoroutine("EnemyDie");
        }
        
        
        
    }


    //method that help change health value outside of this object
    public void TakeDamage(int units)
    {
        health -= units;
        anim.SetBool("DamageRecieve", true);
    }


    //Courotine that wait 5 seconds before dead enemy disapear
    IEnumerator EnemyDie()
    {
        yield return new WaitForSeconds(5f);
        
        Destroy(gameObject);
        
    }
    
    
}//class
