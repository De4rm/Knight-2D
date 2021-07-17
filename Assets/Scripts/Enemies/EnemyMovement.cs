using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

   

    private float speed = 2f;
    private float direction = -1;

    [SerializeField] private float maxBoundPosition;
    [SerializeField] private float minBoundPosition;



    // Update is called once per frame
    void Update()
    {
        MoveInBounds();
    }



    void MoveInBounds()
    {
        Vector2 temp = transform.position;
        
        if((temp.x < maxBoundPosition) && (temp.x > minBoundPosition))
        {
            temp.x += direction * speed * Time.deltaTime;
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
        }
        
        transform.position = temp;
        
    }
    
    
}//class



