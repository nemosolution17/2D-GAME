using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moves a platform to the left and right
public class LeftRightCloud : MonoBehaviour
{
    float dirX, moveSpeed = 5f;
    bool moveRight = true;
    float s;
    // Update is called once per frame

     void Start()
    {
        s = transform.position.x;
    }
    void Update()
    {
        if (transform.position.x > s+4)
            moveRight = false;
        if (transform.position.x < s-4) 
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
}