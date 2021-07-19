using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    
    private Animator anim;


    [SerializeField] private float SecondsBetweenRuns;


    private float playerPosition;
    private float maxBoundPosition;
    private float minBoundPosition;

    private float attackRange;

    private float moveToPosition;
    private float speed = 2f;
    private float direction = -1;
    private float differenceLeftBetweenRun = 0f;

    public bool canMoveInBounds = true;
    
    


    private void Awake()
    {
        anim = GetComponent<Animator>();
        maxBoundPosition = transform.position.x;
        minBoundPosition = maxBoundPosition - 10f;
        attackRange = GetComponent<EnemyAttack>().GetAttackRange();
    }


    // Update is called once per frame
    void Update()
    {
        if (canMoveInBounds)
        {
            MoveInBounds();
        }
        else
        {
            MoveToPlayer();
        }
    }



    void MoveInBounds()
    {

        if (differenceLeftBetweenRun <= 0)
        {
            if (direction < 0)
            {
                Move(minBoundPosition);
            }
            else
            {
                Move(maxBoundPosition);
            }
        }
        else
        {
            anim.SetBool("Run", false);
            differenceLeftBetweenRun -= Time.deltaTime;
        }

    }



    void Move(float toPosition)
    {
        Vector2 temp = transform.position;
        if (temp.x != toPosition)
        {
            temp.x += direction * speed * Time.deltaTime;
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
            
            if (canMoveInBounds)
            {
                ChangeDirection();
            }
        }
        
        transform.position = temp;
    }


    void ChangeDirection()
    {
        direction = -direction;

        Quaternion rotation = transform.rotation;
        
        if(direction<0)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.rotation = rotation;

        differenceLeftBetweenRun = SecondsBetweenRuns;
    }


    void MoveToPlayer()
    {
        Vector2 temp = transform.position;

        direction = (temp.x > playerPosition) ?  -1 : 1;
        
        moveToPosition = playerPosition + (direction * attackRange);

        Move(moveToPosition);
    }


    
    
    //***************************Seters*****************************************************
    public void SetPlayerPosition(float position)
    {
        playerPosition = position;
    }

    public void SetCanMoveInBounds(bool value)
    {
        canMoveInBounds = value;
    }
    

}//class



