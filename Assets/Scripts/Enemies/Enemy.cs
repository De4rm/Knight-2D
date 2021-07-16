using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    private Animator anim;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            anim.SetTrigger("Dead");
            StartCoroutine("EnemyDie");
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
    }


    IEnumerator EnemyDie()
    {
        yield return new WaitForSeconds(5f);
        
        Destroy(gameObject);
        
    }
    
    
}//class
