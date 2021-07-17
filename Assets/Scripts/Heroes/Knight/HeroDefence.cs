using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDefence : MonoBehaviour
{


    private int health = 100;
    

    private Animator anim;



    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {

        if (health <= 0)
        {
            
        }

        Defence();

    }


    void Defence()
    {
        
    }


    public void TakeDamage(int units)
    {
        health -= units;
    }



} //class
