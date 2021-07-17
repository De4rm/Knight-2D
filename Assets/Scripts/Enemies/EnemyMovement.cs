using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    
    private Animator anim;


    [SerializeField] private float SecondsBetweenRuns;
    [SerializeField] private float maxBoundPosition;
    [SerializeField] private float minBoundPosition;
    
    private float speed = 2f;
    private float direction = -1;
    private float differenceLeftBetweenRun = 0f;

    public bool canMoveInBounds = true;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (canMoveInBounds)
        {
            MoveInBounds();
        }
    }



    void MoveInBounds()
    {
        
        if (differenceLeftBetweenRun <= 0)
        {
            Vector2 temp = transform.position;
            
            if ((temp.x < maxBoundPosition) && (temp.x > minBoundPosition))
            {
                temp.x += direction * speed * Time.deltaTime;
                anim.SetBool("Run", true);
            }
            else
            {
                direction = -direction;

                Quaternion rotation = transform.rotation;
                if (temp.x >= maxBoundPosition)
                {
                    rotation.y = 0f;
                    temp.x = maxBoundPosition - 0.1f;
                }
                else
                {
                    temp.x = minBoundPosition + 0.1f;
                    rotation.y = 180f;
                }

                transform.rotation = rotation;

                differenceLeftBetweenRun = SecondsBetweenRuns;

            }

            transform.position = temp;
        }
        else
        {
            anim.SetBool("Run", false);
            differenceLeftBetweenRun -= Time.deltaTime;
        }

    }
    

}//class



