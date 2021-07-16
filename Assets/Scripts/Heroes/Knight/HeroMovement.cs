using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer spr;
    private BoxCollider2D coll;
   [SerializeField]private LayerMask platformlayerMask;
    
    public float speed = 10f;
    public float jumpForce = 20f;

    public HeroAttacks heroAttackScript;
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        heroAttackScript = GetComponent<HeroAttacks>();
    }

    
    void Update()
    {

        Move();
        Jump();
        Roll();

    }



    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");


        myBody.velocity = new Vector2(speed * h, myBody.velocity.y);
        anim.SetInteger("Run", Mathf.Abs((int)h));

        if (h < 0)
        {

            FlipPlayer(180);
            

        }
        else if (h>0)
        {
            
           FlipPlayer(0);
           
        }
    }


    void Jump()
    {
        
        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                anim.SetBool("Jump", true);
                
            }
            else
            {
                anim.SetBool("Jump", false);
            }
        }
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, 
            Vector2.down, 0.1f, platformlayerMask);
        return hit.collider != null;
    }


    void Roll()
    {
        if (IsGrounded())
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Move();
                anim.SetBool("Roll", true);
            }
            else
            {
                anim.SetBool("Roll", false);
            }
        }
    }



    void FlipPlayer(int degree)
    {
        Quaternion temp = transform.rotation;
        temp.y = degree;
        transform.rotation = temp;
    }
    
    
    
}//class
