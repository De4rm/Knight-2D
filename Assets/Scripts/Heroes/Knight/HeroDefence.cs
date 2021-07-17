using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroDefence : MonoBehaviour
{


    private int health = 100;
    private bool inDefenceStance;
    

    private Animator anim;

    public Text healthText;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (health <= 0)
        {
            anim.SetTrigger("Die");
            ///will need to set an ui to restart game or to go to main menu
        }

        inDefenceStance = Defence();

        
        anim.SetBool("Defend", inDefenceStance);

        healthText.text = "Health: " + health;


    }


    bool Defence()
    {
        return Input.GetKey(KeyCode.Space);
    }


    public void TakeDamage(int units)
    {

        if (!inDefenceStance)
        {
            health -= units;
            //******** animation for damage receive
        }
        else
        {
            health --;
            // ******** animation for damage in defence
        }
    }



} //class
